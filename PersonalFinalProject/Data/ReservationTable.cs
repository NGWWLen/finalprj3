using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class ReservationTable
    {
        [Key]
        public int Id { get; set; }

        //Navigation Property
        //A ReservationTable can book one to many Tables 1-*
        [Required]
        public List<RestaurantTable> RestaurantTables { get; set; }

        //Navigation Property
        //A ReservationTable can only be reserved by one Reservation 1-1
        [Required]
        public Reservation Reservation { get; set; } = new();
    }
}
