using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Services.ProductService;

namespace Practice.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

    
        public IActionResult Add()
        {
            ViewBag.Groups = _productService.GetDepartmentWithDefault();
            return View(new Product());
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,DepartmentId,Name,Cost,Amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Groups = _productService.GetDepartmentWithDefault();
            return View(product);
        }

       
        public async Task<IActionResult> Edit(int id = 0)
        {
            ViewBag.Groups = _productService.GetDepartmentWithDefault();
            var student = await _productService.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,DepartmentId,Name,Cost,Amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Groups = _productService.GetDepartmentWithDefault();
            return View(product);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProductList(int departmentId)
        {
            var products = _productService.GetAllAsync(departmentId).Result;
            return View(products);
        }
    }
}
