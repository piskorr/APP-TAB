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
    public class LoginCredentialsController : Controller
    {
        private readonly dbContext _context;

        public LoginCredentialsController(dbContext context)
        {
            _context = context;
        }

        // GET: LoginCredentials
        public async Task<IActionResult> Index()
        {
            var dbContext = _context.LoginCredentials.Include(l => l.Person);
            return View(await dbContext.ToListAsync());
        }

        // GET: LoginCredentials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCredentials = await _context.LoginCredentials
                .Include(l => l.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loginCredentials == null)
            {
                return NotFound();
            }

            return View(loginCredentials);
        }

        // GET: LoginCredentials/Create
        public IActionResult Create()
        {
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Address");
            return View();
        }

        // POST: LoginCredentials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password")] LoginCredentials loginCredentials)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginCredentials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Address", loginCredentials.ID);
            return View(loginCredentials);
        }

        // GET: LoginCredentials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCredentials = await _context.LoginCredentials.FindAsync(id);
            if (loginCredentials == null)
            {
                return NotFound();
            }
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Address", loginCredentials.ID);
            return View(loginCredentials);
        }

        // POST: LoginCredentials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password")] LoginCredentials loginCredentials)
        {
            if (id != loginCredentials.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginCredentials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginCredentialsExists(loginCredentials.ID))
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
            ViewData["ID"] = new SelectList(_context.Person, "ID", "Address", loginCredentials.ID);
            return View(loginCredentials);
        }

        // GET: LoginCredentials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginCredentials = await _context.LoginCredentials
                .Include(l => l.Person)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (loginCredentials == null)
            {
                return NotFound();
            }

            return View(loginCredentials);
        }

        // POST: LoginCredentials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginCredentials = await _context.LoginCredentials.FindAsync(id);
            _context.LoginCredentials.Remove(loginCredentials);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginCredentialsExists(int id)
        {
            return _context.LoginCredentials.Any(e => e.ID == id);
        }
    }
}
