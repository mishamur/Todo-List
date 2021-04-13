using AuntificationMetanit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AuntificationMetanit.Controllers
{
    public class HomeController : Controller
    {
        private AuthContext db;
        public HomeController(AuthContext context)
        {
            db = context;
        }
       
        [Authorize]
        public IActionResult Index()
        {
            User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            ViewBag.IUser = User.Identity.Name;
            if(user != null)
            {   
                
                    return View(user.records.ToList());

            }
                
            return RedirectToAction("CreateRecord");

        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateRecord()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRecord(Record record)
        {
            if(record != null)
            {
                record.RecordId = Guid.NewGuid();
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                user.records.Add(record);
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
       
    }
}
