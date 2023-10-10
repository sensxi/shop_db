﻿using System;
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
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetCoursesAsync();

            if (courses != null)
            {
                return View(courses);
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Courses' is null.");
            }
        }

        // GET: Course/Add
        public IActionResult Add()
        {
            return View(new Course());
        }

        // POST: Course/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("CourseId,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (await _courseService.AddCourseAsync(course))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(course);
        }

        // GET: Course/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if (course != null)
            {
                return View(course);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Course/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("CourseId,Name,Description")] Course course)
        {
            if (ModelState.IsValid)
            {
                if (await _courseService.UpdateCourseAsync(course))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByIdAsync(id.Value);

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
            if (await _courseService.DeleteCourseAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Courses' is null.");
            }
        }

        // GET: Course/GroupList/5
        public async Task<IActionResult> ListGroup(int courseId)
        {
            ViewData["CourseId"] = courseId;
            var groups = await _courseService.GetGroupsByCourseIdAsync(courseId);

            return View(groups);
        }
    }
}
