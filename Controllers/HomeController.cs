using Microsoft.AspNetCore.Mvc;
using RentalAppMVC.Data;
using RentalAppMVC.Models;
using System.Diagnostics;

namespace RentalAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string type, int? maxPrice)
        {
            var properties = _context.Properties
                .Where(p => p.IsAvailable)
                .AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                properties = properties.Where(p => p.Type == type);
            }

            if (maxPrice.HasValue)
            {
                properties = properties.Where(p => p.Price <= maxPrice.Value);
            }

            return View(properties.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
