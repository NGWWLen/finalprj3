using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class RestaurantTable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        //A table can only be located in one area 1-1
        [Required]
        public Area Area { get; set; }


        //Navigation Property
        //A table can be booked in zero to many reservationTable
        public List<ReservationTable> ReservationTables { get; set; } = new();
    }
}
