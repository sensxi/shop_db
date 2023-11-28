using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Practice.Services;
using Practice.Models;

namespace Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataSeedService _dataSeedService;

        public HomeController(IDataSeedService dataSeedService)
        {
            _dataSeedService = dataSeedService;
        }

        public async Task<IActionResult> SeedDatabase()
        {
            var result = await _dataSeedService.SeedDatabaseAsync();
            return Content(result);
        }
    }
}