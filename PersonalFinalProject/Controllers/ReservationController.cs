using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinalProject.Data;
using PersonalFinalProject.Models;
using Microsoft.Data.Sqlite;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace PersonalFinalProject.Controllers
{
    public class ReservationController : Controller
    {
        //Private field
        private ApplicationDbContext _context = new ApplicationDbContext();

        //Constructor
        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin, Manager, Employee, Member")]
        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return View(reservations);
        }

        [Authorize(Roles = "Admin, Manager, Employee, Member")]
        public async Task<IActionResult> Details(int id)
        {
            var r = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);

            if (r == null)
            {
                return NotFound();
            }

            var rvm = new ReservationViewModel();
            rvm.Start = r.Start;
            rvm.Duration = r.Duration;
            rvm.GuestNumber = r.GuestNumber;
            rvm.Notes = r.Notes;
            rvm.FirstName = r.FirstName;
            rvm.LastName = r.LastName;
            rvm.PhoneNumber = r.PhoneNumber;
            rvm.Email = r.Email;
            rvm.Sitting = r.SittingId;
            if (r.Area != null)
            {
                rvm.AreaName = r.Area.Name;
            }
            else
            {
                rvm.AreaName = "";
            }
            rvm.ReservationSource = getReservationSource(r.ReservationSourceId);
            rvm.ReservationStatus = getReservationStatus(r.ReservationStatusId);

            return View(rvm);
        }


        [Authorize(Roles = "Admin, Manager, Employee, Member")]
        [HttpGet]
        public async Task<IActionResult> EditDetails(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.ReservationStatus)
                .FirstOrDefaultAsync(r => r.Id == id);


            var statuses = _context.ReservationStatuses.ToList();
            ViewBag.ReservationStatuses = new SelectList(statuses, "Id", "Name", reservation.ReservationStatus);

            if (reservation == null)
            {
                return NotFound();
            }
            return View(reservation);
        }


        [Authorize(Roles = "Admin, Manager, Employee, Member")]
        [HttpPost]
        public async Task<IActionResult> EditDetails(Reservation s)
        {
            var reservation = await _context.Reservations
                .Include(_ => _.Sitting)
                .Include(_ => _.ReservationStatus)
                .FirstOrDefaultAsync(r => r.Id == s.Id);
            if (reservation == null)
            {
                return NotFound();
            }
            //if (ModelState.IsValid)
            //{

            var existingStatus = await _context.ReservationStatuses.FirstOrDefaultAsync(e => e.Id == s.ReservationStatus.Id);

            if (existingStatus == null)
            {
                return NotFound("Status not found");
            }

            int original = reservation.GuestNumber;

            reservation.GuestNumber = s.GuestNumber;
            reservation.ReservationStatus = existingStatus;
            reservation.Start = s.Start;
            reservation.Duration = s.Duration;





            await _context.SaveChangesAsync();

            if (reservation.ReservationStatus.Name == "cancelled")
            {

                reservation.GuestNumber = 0;

            }

            await _context.SaveChangesAsync();


            var sitting = await _context.Sittings.FirstOrDefaultAsync(sa => sa.Id == reservation.SittingId);


            sitting.Capacity += original;
            await _context.SaveChangesAsync();
            sitting.Capacity -= reservation.GuestNumber;
            _context.Update(sitting);
            await _context.SaveChangesAsync();



            //await _context.SaveChangesAsync();




            return RedirectToAction("Reservation");
            //}
            //return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IList<Sitting> TheSittingId { get; set; }

        [Authorize(Roles = "Admin, Manager, Employee, Member")]

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel rvm)
        {
            //Prepare boolean to prevent pushing to database
            var validBooking = true;

            Reservation newReservation = new Reservation();
            newReservation.Start = rvm.Start;
            newReservation.Duration = rvm.Duration;
            newReservation.GuestNumber = rvm.GuestNumber;
            newReservation.FirstName = rvm.FirstName;
            newReservation.LastName = rvm.LastName;
            newReservation.PhoneNumber = rvm.PhoneNumber;
            newReservation.Email = rvm.Email;
            newReservation.ReservationStatusId = 1;  //1 for pending - default
            newReservation.ReservationSourceId = 1;  //1 for Website - default

            //Notes
            if (rvm.Notes == null)
            {
                newReservation.Notes = "";
            }
            else
            {
                newReservation.Notes = rvm.Notes;
            }

            //SittingId
            var endTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, (rvm.Start.Hour + rvm.Duration), 0, 0);
            if (rvm.Sitting == 0)
            {
                var sqlStartTime = new SqlParameter("@sqlStartTime", rvm.Start);
                var sqlEndTime = new SqlParameter("@sqlEndTime", endTime);

                var result = _context.Sittings
                    .Where(s => s.StartTime <= rvm.Start && s.EndTime >= endTime && s.Id != 4)
                    .FirstOrDefault()?.Id;

                if (result != null)
                {
                    //If there's existing sittingId at the said time and date, means booking is valid
                    newReservation.SittingId = (int)result;
                }
                else
                {
                    validBooking = false;
                }

            }

            //Check Capacity in sittings
            if (validBooking)
            {
                var capacity = _context.Sittings
                    .Where(s => s.StartTime <= rvm.Start && s.EndTime >= endTime && s.Id != 4)
                    .FirstOrDefault()?.Capacity;

                if (capacity < rvm.GuestNumber)
                {
                    validBooking = false;
                }
                //If there's enough capacity, means booking is valid
            }

            //Area --> Will be set up according to special note request & will be done during staff confirmation
            newReservation.Area = null;

            if (validBooking)
            {
                //Register the new Reservation
                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();

                //Reduce the capacity of sittings! (UPDATE DTB)
                var sittingToUpdate = _context.Sittings.FirstOrDefault(s => s.Id == newReservation.SittingId);
                if (sittingToUpdate != null)
                {
                    sittingToUpdate.Capacity = sittingToUpdate.Capacity - newReservation.GuestNumber;
                    _context.SaveChanges();
                }

                //After a staff confirmed this reservation, we also have to fill the Reservation-Table table
            }
            return View();
        }

        private string getReservationStatus (int status)
        {
            switch (status)
            {
                case 1:
                    return "Pending";
                    break;
                case 2:
                    return "Confirmed";
                    break;
                case 3:
                    return "Canceled";
                    break;
                case 4:
                    return "Seated";
                    break;
                case 5:
                    return "Completed";
                    break;
                default:
                    break;
            }
            return "";
        }
        private string getReservationSource(int source)
        {
            switch (source)
            {
                case 1:
                    return "Website";
                    break;
                case 2:
                    return "Mobile App";
                    break;
                case 3:
                    return "Email";
                    break;
                case 4:
                    return "Phone Call";
                    break;
                case 5:
                    return "In Person";
                    break;
                default:
                    break;
            }
            return "";
        }
    }
}
