using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task9.Models;
using Task9.Services.GroupService;

namespace Task9.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var groups = await _groupService.GetAllAsync();
            return View(groups);
        }

        // GET: Group/Add
        public IActionResult Add()
        {
            ViewBag.Courses = _groupService.GetCourseWithDefault();

            return View(new Group());
        }

        // POST: Group/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                if(await _groupService.AddAsync(group))
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Content($"Group with name: '{group.Name}' or course '{group.CourseId}' already exist");
                }
            }
            
            ViewBag.Courses = _groupService.GetCourseWithDefault();
            return View(group);
        }


        // GET: Group/Edit
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Courses = _groupService.GetCourseWithDefault();
            var group = await _groupService.GetAsync(id);
            if (group != null)
            {
                return View(group);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Group/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                if(await _groupService.UpdateAsync(group))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content($"Group with name: '{group.Name}' or course '{group.CourseId}' already exist");
                }
            }
            ViewBag.Courses = _groupService.GetCourseWithDefault();
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tgroup = await _groupService.GetAsync(id.Value);
            if (tgroup == null)
            {
                return NotFound();
            }

            var hasStudents = await _groupService.GroupHasStudentsAsync(tgroup.Id);
            ViewData["HasStudents"] = hasStudents;

            return View(tgroup);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var hasStudents = await _groupService.GroupHasStudentsAsync(id);
            if (hasStudents)
            {
                ViewData["ErrorMessage"] = "Cannot delete group with students.";
                return View("Delete", await _groupService.GetAsync(id));
            }

            await _groupService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GroupList(int courseId)
        {
            var groups = await _groupService.GetAllAsync(courseId);

            return View(groups);
        }


    }
}
