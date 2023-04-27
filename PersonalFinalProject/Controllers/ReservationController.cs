using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalFinalProject.Data;
using PersonalFinalProject.Models;
using Microsoft.Data.Sqlite;

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

        public async Task<IActionResult> Index()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return View(reservations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var r = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
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
        public async Task<IActionResult> Create(ReservationViewModel rvm)
        {
            //Prepare boolean to prevent pushing to database
            var validBooking = true;
            var sittingId = await getSittingId(rvm);
            // WIP - var areaId = getAreaId(rvm, sittingId);


            //Variable to store the new Reservation --> Right now we are mostly hard coding it, we will work on it in the future
            Reservation newReservation = new Reservation();
            newReservation.Sitting = await _context.Sittings.FindAsync(sittingId);
            newReservation.Start = getStartDateTime(rvm);
            newReservation.Duration = getDuration(rvm);
            newReservation.GuestNumber = rvm.GuestNumber;
            newReservation.FirstName = rvm.FirstName;
            newReservation.LastName = rvm.LastName;
            newReservation.PhoneNumber = rvm.PhoneNumber;
            newReservation.Email = rvm.Email;
            newReservation.Notes = rvm.Notes;                      //Sitting Id for lunch 12pm
            newReservation.ReservationStatus = await _context.ReservationStatuses.FindAsync(1); //1 for pending
            newReservation.ReservationSource = await _context.ReservationSources.FindAsync(1);  //1 for Website
            newReservation.User = null;                                                         //For now we dont bother about user until we create authorization
            newReservation.Area = await _context.Areas.FindAsync(2);                            //2 for Outside

            //Register the new Reservation
            _context.Reservations.Add(newReservation);
            await _context.SaveChangesAsync();

            var registeredReservation = await _context.Reservations.OrderByDescending(r => r.Id).LastAsync();
            Console.WriteLine(registeredReservation);

            //Need to update ReservationTables (pass the registered reservation with last id)
            return View();
        }

        private async Task<int> getSittingId(ReservationViewModel rvm)
        {
            DateTime startDateTime, endDateTime;

            //From the sitting input, figure out the start and end time of reservation
            switch (rvm.Sitting)
            {
                case 1:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 7, 0, 0);
                    endDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 11, 0, 0);
                    break;
                case 2:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 12, 0, 0);
                    endDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 16, 0, 0);
                    break;
                case 3:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 18, 0, 0);
                    endDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 22, 0, 0);
                    break;
                case 4:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 7, 0, 0);
                    endDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 22, 0, 0);
                    break;
                default:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, rvm.Sitting, 0, 0);
                    endDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, (rvm.Sitting + 2), 0, 0);
                    break;
            }

            //Parameter for SQL Query
            var sqlStartDateTime = new SqliteParameter("@sqlStartDateTime", startDateTime);
            var sqlEndDateTime = new SqliteParameter("@sqlEndDateTime", endDateTime);

            //Get Sitting where the start date time & start end time ...
            var Sitting = await _context.Sittings.FirstOrDefaultAsync(s => s.StartTime == startDateTime && s.EndTime == endDateTime);

            if (Sitting != null)
            {
                return Sitting.Id;
            }

            return 1;  //If sitting Id cannot be found, return 1, means its inappropriate reservation ??? Need to do try catch or something
        }

        /*
        private async Task<int> getAreaId(ReservationViewModel rvm, int sittingId)
        {
            var _area = rvm.Area;
            var _sittingId = sittingId;
            var _guestNumber = rvm.GuestNumber;


            //Check if there are available tables in the area

            var sqlAreaId = new SqliteParameter("@sqlAreaId", _area);
            var sqlSittingId = new SqliteParameter("@sqlSittingId", _sittingId);
            var sqlGuestNumber = new SqliteParameter("@sqlGuestNumber", _guestNumber);

            var isAreaAvailableQueryResult = _context.RestaurantTables.FromSqlRaw(
            "SELECT [RestaurantTables].[AreaId] From [RestaurantTables] "
            + "where [RestaurantTables].[Id] NOT IN ( "
            + "SELECT [ReservationTables].[RestaurantTableId] "
            + "from [RestaurantTables], [Reservations] "
            + "where [RestaurantTables].[ReservationId] = [Reservations].[Id] "
            + "and [Reservations].[SittingId] = @sqlSittingId ) "
            + "GROUP BY [RestaurantTables].[AreaId] "
            + "HAVING COUNT(*) >= @sqlGuestNumber and [RestaurantTables].[AreaId] >= @sqlAreaId; "
            , sqlSittingId, sqlGuestNumber, sqlAreaId);

            var a = isAreaAvailableQueryResult;
            var b = isAreaAvailableQueryResult;
            var c = isAreaAvailableQueryResult;
            var d = isAreaAvailableQueryResult;

            //Broke here.
            var resultAreaObject = isAreaAvailableQueryResult.Select(rt => rt.Area).ToList().FirstOrDefault();

            var e = resultAreaObject;
            var f = resultAreaObject;
            var g = resultAreaObject;
            var h = resultAreaObject;

            var hello = "string";
             if (resultAreaObject.Id == _area)
                return _area;
            return -999;


        }
        */
        private DateTime getStartDateTime(ReservationViewModel rvm)
        {
            DateTime startDateTime;
            switch(rvm.Sitting)
            {
                case 1:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 7, 0, 0);
                    break;
                case 2:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 12, 0, 0);
                    break;
                case 3:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 18, 0, 0);
                    break;
                case 4:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, 7, 0, 0);
                    break;
                default:
                    startDateTime = new DateTime(rvm.Start.Year, rvm.Start.Month, rvm.Start.Day, rvm.Sitting, 0, 0);
                    break;
            }
            return startDateTime;
        }

        private int getDuration(ReservationViewModel rvm)
        {
            int duration;
            switch (rvm.Sitting)
            {
                case 1:
                    duration = 4;
                    break;
                case 2:
                    duration = 4;
                    break;
                case 3:
                    duration = 4;
                    break;
                case 4:
                    duration = 15;
                    break;
                default:
                    duration = 2;
                    break;
            }
            return duration;
        }


    }
}
