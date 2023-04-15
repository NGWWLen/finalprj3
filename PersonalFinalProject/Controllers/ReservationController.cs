using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonalFinalProject.Data;

namespace PersonalFinalProject.Controllers
{
    public class ReservationController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;


        }


        public IActionResult Reservations()
        {
            return View();
        }

        [Route("~/Reservation/Sittings")]
        public IActionResult Sittings()
        {
            /*var reservations = _context.Reservations.ToList();
            return View(reservations);*/
            return View();
        }
        

        [Route("~/Reservation/Reservations/Details")]
        public IActionResult Details()
        {


            return View();
        }
    }
}
