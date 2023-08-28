using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Controllers
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
                var applicationDbContext = _context.Groups.Include(t => t.Course);
                return View(await applicationDbContext.ToListAsync());
        }

        // GET: Group/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateCourse();
            if (id == 0)
                return View(new Group());
            else
                return View(_context.Groups.Find(id));
        }

        // POST: Group/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("GroupId,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                if (group.GroupId == 0)
                    _context.Add(group);
                else
                    _context.Update(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateCourse();
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groups == null)
            {
                return NotFound();
            }

            var tgroup = await _context.Groups
                .Include(t => t.Course)
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (tgroup == null)
            {
                return NotFound();
            }

            return View(tgroup);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groups == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Groups'  is null.");
            }
            var tgroup = await _context.Groups.FindAsync(id);
            if (tgroup != null)
            {
                _context.Groups.Remove(tgroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GroupList(int courseId)
        {
            var groups = _context.Groups.Where(g => g.CourseId == courseId).ToList();

            return View(groups);
        }
        
        [NonAction]
        public void PopulateCourse()
        {
            var CourseCollection = _context.Courses.ToList();
            Course DefaultCourse = new Course() { CourseId = 0, Name = "Choose a Category" };
            CourseCollection.Insert(0, DefaultCourse);
            ViewBag.Courses = CourseCollection;
        }
        
    }
}
