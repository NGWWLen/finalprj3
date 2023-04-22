using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class Sitting
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the starting date and time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please enter the ending date and time")]
        public DateTime EndTime { get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the capacity of sitting")]
        public int Capacity{ get; set; }

        [Required(ErrorMessage = "Please enter the status of sitting")]
        public Boolean Active { get; set; }

        //Navigation Property
        //A seating belongs to one and ONLY one SittingType
        public SittingType SittingType { get; set; }
        //Navigation Property
        //A seating can be booked by 0-* reservations
        public List<Reservation> Reservations { get; set; } = new();
    }
}
