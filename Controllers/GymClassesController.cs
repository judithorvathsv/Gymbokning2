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
using Gymbokning.Models.ViewModels;

namespace Gymbokning.Controllers
{
    public class GymClassesController : Controller
    {
        private readonly ApplicationDbContext _context;    


        public GymClassesController(ApplicationDbContext context)
        {
            _context = context;
          
        }




        // GET: GymClasses
        public async Task<IActionResult> Index()
        {          
            if (_context.ApplicationUserGymClass != null) {
                var model = await _context.GymClass.Include(g => g.AttendingMembers).ThenInclude(a => a.ApplicationUser).ToListAsync();
                var modelOrdered = model.OrderByDescending(m => m.StartTime);
            return View(modelOrdered);
            }
            else {
                var model = await _context.GymClass.ToListAsync();
                var modelOrdered = model.OrderByDescending(m => m.StartTime);
                return View(modelOrdered);
            }
        }




        public async Task<IEnumerable<BookedGymClassViewModel>> GetModel()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _context.GymClass.Select(i => new BookedGymClassViewModel
            {
                Id = i.Id,
                Name = i.Name,
                StartTime = i.StartTime,
                Duration = i.Duration,
                Description = i.Description,
                ApplicationUserGymClassIsBooked = i.AttendingMembers.Any(a => a.ApplicationUserId == userId)
            }).ToListAsync();

            var modelOrdered = model.OrderByDescending(m => m.StartTime);
            return modelOrdered;
        }




        public async Task<IActionResult> BookedGymClassAllList()
        {
            var model = await GetModel();

            //all gymclasses regardless of StartTime
             return View("BookedGymClassAllListView", model);           
        }        
        
        public ActionResult HistoryToNewGymClasses() => RedirectToAction("BookedGymClass");
       



        public async Task<IActionResult> BookedGymClass()
        {
            var model = await GetModel();
    
            //only classes which StartTime is not older then today
           var newestModel = model.Where(t => t.StartTime > DateTime.Now);          
           return View("BookGymClassView", newestModel);           
        }

        public ActionResult HistoryToAllGymClasses() => RedirectToAction("BookedGymClassAllList");




        public async Task<IActionResult> BookedGymClassHistory()
        {
            var model = await GetModel();
    
            //only classes which StartTime is older then today AND class is booked by logged user
            var oldBookedClasses = model.Where(t => t.StartTime < DateTime.Now && t.ApplicationUserGymClassIsBooked==true);
            return View("OldBookedGymClassesView", oldBookedClasses);
        }




        public async Task<IActionResult> CurrentlyBookedClasses()
        {
            var model = await GetModel();
    
            //only classes which StartTime is not older then today AND class is booked by logged user
            var oldBookedClasses = model.Where(t => t.StartTime > DateTime.Now && t.ApplicationUserGymClassIsBooked == true);
            return View("CurrentlyBookedClassesView", oldBookedClasses);
        }




        [Authorize]
        //gymClass id
        public async Task<IActionResult> BookingToggle(int? id)
        {
            if (id == null) return NotFound();
         
            else
            {
                //this user is logged in             
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);               

                //which class?
                var gymClass = await _context.GymClass.FirstOrDefaultAsync(g => g.Id == id);              

                //logged user is on this class 
                var b = await _context.ApplicationUserGymClass.FirstOrDefaultAsync(t => t.ApplicationUserId == userId && t.GymClassId == id);

                //user is not on this class: add user to this class (add into ApplicationUserGymClass db)
                if (b == null) {                    
                    var classAndMember = new ApplicationUserGymClass
                    {
                        ApplicationUser = _context.Users.ToList().FirstOrDefault(u => u.Id == userId),
                        GymClass = gymClass,                       
                    };  
                    _context.ApplicationUserGymClass.Add(classAndMember);                                    
                 }
                else
                {
                    _context.ApplicationUserGymClass.Remove(b);                   
                }
                await _context.SaveChangesAsync();

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




        [Authorize(Roles = "Admin")]
        // GET: GymClasses/Create
        public IActionResult Create()
        {
            return View();
        }




        [Authorize(Roles = "Admin")]
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




        [Authorize(Roles ="Admin")]
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




        [Authorize(Roles = "Admin")]
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




        [Authorize(Roles = "Admin")]
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




        [Authorize(Roles = "Admin")]
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
