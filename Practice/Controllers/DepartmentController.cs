using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Services.DepartmentService;
using Practice.Services.DepartmentService;

namespace Practice.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllAsync();
            return View(departments);
        }
        
        public IActionResult Add()
        {
            ViewBag.Courses = _departmentService.GetShopWithDefault();

            return View(new Department());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,ShopId,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                if(await _departmentService.AddAsync(department))
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Content($"Department with name: '{department.Name}' or shop '{department.ShopId}' already exist");
                }
            }
            
            ViewBag.Courses = _departmentService.GetShopWithDefault();
            return View(department);
        }


       
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Courses = _departmentService.GetShopWithDefault();
            var department = await _departmentService.GetAsync(id);
            if (department != null)
            {
                return View(department);
            }
            else
            {
                return NotFound();
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,ShopId,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                if(await _departmentService.UpdateAsync(department))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content($"Department with name: '{department.Name}' or shop '{department.ShopId}' already exist");
                }
            }
            ViewBag.Courses = _departmentService.GetShopWithDefault();
            return View(department);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tdepartment = await _departmentService.GetAsync(id.Value);
            if (tdepartment == null)
            {
                return NotFound();
            }

            return View(tdepartment);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _departmentService.DeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewData["ErrorMessage"] = "Cannot delete department with products.";
            return View("Delete", await _departmentService.GetAsync(id));
        }

        public async Task<IActionResult> DepartmentList(int shopId)
        {
            var departments = await _departmentService.GetAllAsync(shopId);

            return View(departments);
        }


    }
}
