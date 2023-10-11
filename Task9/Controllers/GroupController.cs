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
            var groups = await _groupService.GetGroupsAsync();
            return View(groups);
        }

        // GET: Group/Add
        public IActionResult Add()
        {
            PopulateCourse();

            return View(new Group());
        }

        // POST: Group/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("GroupId,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _groupService.AddGroupAsync(group);
                return RedirectToAction(nameof(Index));
            }
            PopulateCourse();
            return View(group);
        }


        // GET: Group/Edit
        public async Task<IActionResult> Edit(int id)
        {
            PopulateCourse();
            var group = await _groupService.GetGroupByIdAsync(id);
            return View(group);
        }

        // POST: Group/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("GroupId,CourseId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _groupService.EditGroupAsync(group);
                return RedirectToAction(nameof(Index));
            }
            PopulateCourse();
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tgroup = await _groupService.GetGroupByIdAsync(id.Value);
            if (tgroup == null)
            {
                return NotFound();
            }

            var hasStudents = await _groupService.GroupHasStudentsAsync(tgroup.GroupId);
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
                return View("Delete", await _groupService.GetGroupByIdAsync(id));
            }

            await _groupService.DeleteGroupAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GroupList(int courseId)
        {
            var groups = await _groupService.GetGroupsByCourseIdAsync(courseId);

            return View(groups);
        }

        [NonAction]
        public void PopulateCourse()
        {
            var courseCollection = _groupService.GetCourseCollectionWithDefault();
            ViewBag.Courses = courseCollection;
        }
    }
}
