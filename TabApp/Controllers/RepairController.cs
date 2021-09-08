using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Controllers
{
    public class RepairController : Controller
    {
        private readonly dbContext _context;

        public RepairController(dbContext context)
        {
            _context = context;
        }

        // GET: Repair
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.Repair.Include(r => r.Item);
            return View(await dbContext.ToListAsync());
        }

        // GET: Repair/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repair
                .Include(r => r.Item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }
        public IActionResult Add()
        {
            return View();
        }

        // GET: Repair/Create/itemId
        public async Task<IActionResult> Create(int? itemID)
        {
            if (itemID != null)
            {
                var item = await _context.Item.FindAsync(itemID);
                if (item == null)
                {
                    return NotFound();
                }
                ViewBag.ItemID = itemID;
                ViewBag.ItemSerialNumber = item.SerialNumber;
                ViewBag.ItemDescription = item.Description;
                
            }

            //ViewData["ItemID"] = new SelectList(_context.Item, "ID", "Description");
            return View();
        }

        // POST: Repair/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? itemID, [Bind("AdmissionDate,IssueDate,Cost,Warranty,Status,PickupCode")] Repair repair, [Bind("SerialNumber,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                if(itemID != null)
                    repair.ItemID = itemID;
                else
                    repair.Item = item;
                
                _context.Add(repair);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repair);
        }

        // GET: Repair/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repair.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Item, "ID", "Description", repair.ItemID);
            return View(repair);
        }

        // POST: Repair/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AdmissionDate,IssueDate,Cost,Warranty,Status,PickupCode,ItemID")] Repair repair)
        {
            if (id != repair.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repair);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairExists(repair.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemID"] = new SelectList(_context.Item, "ID", "Description", repair.ItemID);
            return View(repair);
        }

        // GET: Repair/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repair = await _context.Repair
                .Include(r => r.Item)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (repair == null)
            {
                return NotFound();
            }

            return View(repair);
        }

        // POST: Repair/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repair = await _context.Repair.FindAsync(id);
            _context.Repair.Remove(repair);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairExists(int id)
        {
            return _context.Repair.Any(e => e.ID == id);
        }
    }
}
