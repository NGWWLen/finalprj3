using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinalProject.Data;
using PersonalFinalProject.Models;

namespace PersonalFinalProject.Controllers
{
    public class RestaurantController : Controller
    {
        //Private field
        private ApplicationDbContext _context = new ApplicationDbContext();

        //Constructor
        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var restaurant = await _context.Restaurants.ToListAsync();
            return View(restaurant);
        }

        public async Task<IActionResult> Details(int id)
        {
            var r = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
            if (r == null)
            {
                return NotFound();
            }
            return View(r);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RestaurantViewModel r)
        {
            var newRestaurant = new Restaurant();
            newRestaurant.Name = r.Name;

            _context.Restaurants.Add(newRestaurant);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}
