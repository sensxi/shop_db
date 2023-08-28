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
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult SeedDatabase()
        {
            // Check if the database is already seeded
            if (_context.Courses.Any())
            {
                return Content("Database already seeded.");
            }


            List<Course> courses = new List<Course>
            {
                new Course { Name = "math", Description = "first course" },
                new Course { Name = "english", Description = "second course" },
                new Course { Name = "programming", Description = "course about programming in c#" },
                new Course { Name = "philosophy", Description = "........." },
                // Add more entities as needed
            };

            // Add the entities to the DbContext and save changes to the database
            _context.Courses.AddRange(courses);
            _context.SaveChanges();

            List<Group> groups = new List<Group>
            {
                new Group { Name = "Group A", CourseId = courses[0].CourseId },
                new Group { Name = "Group B", CourseId = courses[1].CourseId },
                new Group { Name = "Group C", CourseId = courses[2].CourseId },
                new Group { Name = "Group A(1)", CourseId = courses[0].CourseId },
                new Group { Name = "Group A(2)", CourseId = courses[0].CourseId },
                new Group { Name = "Group C(1)", CourseId = courses[2].CourseId }, 
                // Add more groups as needed
            };

            _context.Groups.AddRange(groups);
            _context.SaveChanges();

            List<Student> students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", GroupId = groups[0].GroupId },
                new Student { FirstName = "Jane", LastName = "Smith", GroupId = groups[0].GroupId },
                new Student { FirstName = "Michael", LastName = "Johnson", GroupId = groups[1].GroupId },
                new Student { FirstName = "John", LastName = "Smith", GroupId = groups[0].GroupId },
                new Student { FirstName = "Jane", LastName = "Johnson", GroupId = groups[1].GroupId },
                new Student { FirstName = "Michael", LastName = "Shumaher", GroupId = groups[1].GroupId },
                new Student { FirstName = "Test", LastName = "Test", GroupId = groups[2].GroupId },

            };

            _context.Students.AddRange(students);
            _context.SaveChanges();
            return Content("Database seeded successfully.");
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            return _context.Courses != null ?
                        View(await _context.Courses.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
        }

        // GET: Course/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Course());
            else
                return View(_context.Courses.Find(id));
        }

        // POST: Course/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CourseId,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.CourseId == 0)
                    _context.Add(course);
                else
                    _context.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Course/GroupList/5
        public async Task<IActionResult> ListGroup(int courseId)
        {
            ViewData["CourseId"] = courseId;
            var groups = _context.Groups.Where(g => g.CourseId == courseId).ToList();

            return View(groups);
        }
    }
}
