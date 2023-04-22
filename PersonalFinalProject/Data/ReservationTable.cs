using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class ReservationTable
    {
        [Key]
        public int Id { get; set; }

        //Navigation Property
        //A ReservationTable can book one to one table
        [Required]
        public int RestaurantTableId { get; set; }
        public RestaurantTable RestaurantTable { get; set; }

        //Navigation Property
        //A ReservationTable can only be reserved by one Reservation
        [Required]
        public Reservation Reservation { get; set; }
    }
}
