using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice.Models;
using Practice.Services.ShopService;

namespace Practice.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;
        
        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        
        public async Task<IActionResult> Index()
        {
            var shops = await _shopService.GetAllAsync();

            if (shops != null)
            {
                return View(shops);
            }
            else
            {
                return Problem("Entity set 'ApplicationDbContext.Shops' is null.");
            }
        }
        
        public IActionResult Add()
        {
            return View(new Shop());
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,Description")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                if (await _shopService.AddAsync(shop))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content($"Shop with name: {shop.Name} already exist");
                }
            }
            return View(shop);
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            var shops = await _shopService.GetAsync(id);

            if (shops != null)
            {
                return View(shops);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Description")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                if (await _shopService.UpdateAsync(shop))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Content($"Shops with name: {shop.Name} already exist");
                }
            }
            return View(shop);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _shopService.GetAsync(id.Value);

            if (shops == null)
            {
                return NotFound();
            }

            return View(shops);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (await _shopService.DeleteAsync(id))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewData["ErrorMessage"] = "Cannot delete department with students.";
            return View("Delete", await _shopService.GetAsync(id));
        }
    }
}
