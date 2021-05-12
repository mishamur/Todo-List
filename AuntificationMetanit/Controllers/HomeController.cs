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
        public async Task<IActionResult> Index(SortState sortState = SortState.DateAsc)
        {
            User user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);
            ViewBag.IUser = User.Identity.Name;
            if(user != null)
            {
                //var rec = db.Records.Where(p => p.UserId == user.UserId).ToList();
                IQueryable<Record> rec = db.Records.Where(p => p.UserId == user.UserId);
                
                ViewData["DateSort"] = sortState == SortState.DateAsc ? SortState.DateDesc : SortState.DateAsc;
               
                rec = sortState switch
                {
                    SortState.DateDesc => rec.OrderByDescending(r => r.DateBegin),
                    SortState.DateAsc => rec.OrderBy(r => r.DateBegin),
                    _ => rec.OrderBy(r => r.DateBegin),
                };

               // var rec = user.Records.ToList();    
                return View(await rec.AsNoTracking().ToListAsync());

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
            
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                if(record is Meeting)
                {
                    record =(Meeting) record;
                }
                user.Records.Add(record);
                
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult CreateMeeting()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMeeting(Meeting meeting)
        {

            if(meeting != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                user.Records.Add(meeting);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");

        }

        [Authorize]
        public IActionResult CreateCase()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCase(Case cases)
        {
            if(cases != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
                user.Records.Add(cases);
                await db.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }


        [Authorize]
        public async Task<IActionResult> Edit(Guid? RecordId)
        {
            if(RecordId != null)
            {
                Record record = await db.Records.FirstOrDefaultAsync(r => r.RecordId == RecordId);
                if (record != null)
                    return View(record);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Meeting record)
        {

            
            if(record != null)
            {

                if (record.Discriminator == "Record")
                {
                    Record record1 = new Record
                    {
                        DateBegin = record.DateBegin,
                        Discriminator = record.Discriminator,
                        RecordId = record.RecordId,
                        Theme = record.Theme,
                        UserId = record.UserId
                    };
                    db.Records.Update(record1);
                    await db.SaveChangesAsync();

                }
                else if (record.Discriminator == "Case")
                {
                    Case cases = new Case
                    {
                        DateBegin = record.DateBegin,
                        Discriminator = record.Discriminator,
                        RecordId = record.RecordId,
                        Theme = record.Theme,
                        UserId = record.UserId,
                        DateEnd = record.DateEnd
                       
                    };
                    db.Records.Update(cases);
                    await db.SaveChangesAsync();

                }
                else
                {
                    db.Records.Update(record);
                    await db.SaveChangesAsync();

                }


            }
            return RedirectToAction("Index");

        }

        [Authorize]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid? RecordId)
        {
            if(RecordId != null)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

                Record record = await db.Records.FirstOrDefaultAsync(r => r.RecordId == RecordId &&
                r.UserId == user.UserId);
                if (record != null)
                    return View(record);
            }
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid? RecordId)
        {
            if(RecordId != null)
            {
                Record record = await db.Records.FirstOrDefaultAsync(r => r.RecordId == RecordId);
                if(record != null)
                {
                    db.Records.Remove(record);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();

        }



    }
}
