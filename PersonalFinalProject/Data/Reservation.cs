using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public int Duration { get; set; }
        public string GuestNumber { get; set; }
        public string Notes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Navigation Property
        //One reservation may be booked by ONE guest or ONE user 0-1
        public User? User { get; set; }

        //One reservation can book ONE to MANY sittings 1-*
        public List<Sitting> Sittings { get; set; }

        //One reservation may book ONE to MANY tables 1-*
        public List<ReservationTable> ReservationTables { get; set; } = new();

        //One reservation can only have ONE status at the time 1-1
        public ReservationStatus ReservationStatus { get; set; }

        //One reservation is always originated from ONE and ONLY ONE source 1-1
        public ReservationSource ReservationSource { get; set; }

  
    }
}
