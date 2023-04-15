using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonalFinalProject.Data;
using PersonalFinalProject.Models;

namespace PersonalFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

           /* var restaurant = new Restaurant { Name = "Bean Scene" };
            _context.Restaurants.Add(restaurant);

            restaurant.Areas.Add(new Area { Name = "Main" });
            restaurant.Areas.Add(new Area { Name = "Outside" });
            restaurant.Areas.Add(new Area { Name = "Balcony" });


            foreach (var area in restaurant.Areas)
            {
                for (int i = 1; i < 11; i++)
                {
                    area.RestaurantsTables.Add(new RestaurantTable { Name = $"{area.Name[0]}{i} " });
                }
            }
            _context.SaveChanges();*/

        /*    var sitting = new Sitting { Name = "", SittingTypes = new List<SittingType>() };
            
            _context.Sittings.Add(sitting);
            sitting.SittingTypes.Add(new SittingType { Name = "Breakfast" });
            sitting.SittingTypes.Add(new SittingType { Name = "Lunch" });
            sitting.SittingTypes.Add(new SittingType { Name = "Dinner" });
            sitting.SittingTypes.Add(new SittingType { Name = "SpecialEvent" });

            _context.SaveChanges();*/


        }

        public IActionResult Index()
        {
            return View();
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