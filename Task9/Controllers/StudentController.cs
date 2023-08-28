﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task9.Models;

namespace Task9.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Student/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            PopulateGroup();
            if (id == 0)
                return View(new Student());
            else
                return View(_context.Students.Find(id));
        }

        // POST: Student/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("StudentId,GroupId,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == 0)
                    _context.Add(student);
                else
                    _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateGroup();
            return View(student);
        }
        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Group)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> StudentList(int groupId)
        {
            var students = _context.Students.Where(g => g.GroupId == groupId).ToList();

            return View(students);
        }

        [NonAction]
        public void PopulateGroup()
        {
            var GroupCollection = _context.Groups.ToList();
            Group DefaultGroup = new Group() { GroupId = 0, Name = "Choose a Category" };
            GroupCollection.Insert(0, DefaultGroup);
            ViewBag.Groups = GroupCollection;
        }
    }
}