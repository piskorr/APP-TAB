using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TabApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TabApp.Enums;

namespace TabApp.Controllers
{
    public class UserRepairsController : Controller
    {
        private readonly dbContext _context;

        public UserRepairsController(dbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {   
            var currentUserID = await _context.Person.Where(u => u.LoginCredentials.UserName == User.Identity.Name).Select(p => p.ID).FirstAsync();
            /////////

            var items = _context.Item.Include(i => i.Repair).Where(item=>item.Person.ID == currentUserID).ToListAsync();

            var repairs  = new List<Repair>();
            foreach(var item in items.Result)
            {
            foreach(var repair in item.Repair)
            {
                var tmpRepair =  await _context.Repair.Include(r => r.PickupCode).Include(r => r.RepairStatus).FirstOrDefaultAsync(r => r.ID == repair.ID);
                repairs.Add(tmpRepair);
            }
            }

            return View(repairs);
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.ID == id);
        }
    }
}
