using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task9.Models;
using Task9.Services;

namespace Task9.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetStudentsWithGroupsAsync();
            return View(students);
        }

        // GET: Student/Add
        public IActionResult Add()
        {
            PopulateGroup();
            return View(new Student());
            
        }

        // POST: Student/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("StudentId,GroupId,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            PopulateGroup();
            return View(student);
        }

        // GET: Student/Edit
        public async Task<IActionResult> Edit(int id = 0)
        {
            PopulateGroup();
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("StudentId,GroupId,FirstName,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentService.EditStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            PopulateGroup();
            return View(student);
        }
        
        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
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
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> StudentList(int groupId)
        {
            var students = _studentService.GetStudentsByGroupIdAsync(groupId).Result;
            return View(students);
        }

        [NonAction]
        public void PopulateGroup()
        {
            ViewBag.Groups = _studentService.GetGroupsWithDefault();
        }
    }
}
