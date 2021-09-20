using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gymbokning.Data;
using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Bogus;

namespace Gymbokning.Controllers
{
    public class GymClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly Faker faker;
        private readonly UserManager<ApplicationUser> userManager;



        public GymClassesController(ApplicationDbContext context)
        {
            _context = context;
            faker = new Faker();
        }

        // GET: GymClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.GymClass.ToListAsync());
        }

     


        [Authorize]
        //gymClass id
        public async Task<IActionResult> BookingToggle(int? id)
        {
            if (id == null) return NotFound();
         
            else
            {
                //which user is logged in?              
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);               

                //which class?
                var gymClass = await _context.GymClass.FirstOrDefaultAsync(g => g.Id == id);              

                //logged user is on this class?  
                var b = await _context.ApplicationUserGymClass.FirstOrDefaultAsync(t => t.ApplicationUserId == userId && t.GymClassId == id);
                

                //user is not on this class: add user to this class
                if (b == null) {      

                            //create user+course row in the ApplicationUserGymClass db
                            var classAndMember = new ApplicationUserGymClass
                            {
                                ApplicationUser = _context.Users.ToList().FirstOrDefault(u => u.Id == userId),                                      
                                GymClass = gymClass,
                            }; 

                          _context.ApplicationUserGymClass.Add(classAndMember);
                          await _context.SaveChangesAsync();
                 }

                //remove user from this class:
                else
                {
                    _context.Remove(b);
                    _context.SaveChanges();
                } 
                return RedirectToAction("Details", new { id = gymClass.Id });
            }      
        }
    

        

        // GET: GymClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymClass = await _context.GymClass.Include(g => g.AttendingMembers).ThenInclude(a => a.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Id == id);


            if (gymClass == null)
            {
                return NotFound();
            }

            return View(gymClass);
        }




        [Authorize]
        // GET: GymClasses/Create
        public IActionResult Create()
        {
            return View();
        }




        [Authorize]
        // POST: GymClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gymClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gymClass);
        }




        [Authorize]
        // GET: GymClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymClass = await _context.GymClass.FindAsync(id);
            if (gymClass == null)
            {
                return NotFound();
            }
            return View(gymClass);
        }




        [Authorize]
        // POST: GymClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,Duration,Description")] GymClass gymClass)
        {
            if (id != gymClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gymClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GymClassExists(gymClass.Id))
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
            return View(gymClass);
        }




        [Authorize]
        // GET: GymClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gymClass = await _context.GymClass
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gymClass == null)
            {
                return NotFound();
            }

            return View(gymClass);
        }




        [Authorize]
        // POST: GymClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gymClass = await _context.GymClass.FindAsync(id);
            _context.GymClass.Remove(gymClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




        private bool GymClassExists(int id)
        {
            return _context.GymClass.Any(e => e.Id == id);
        }
    }
}
