namespace PersonalFinalProject.Data
{
    public class ReservationTable
    {
        public int Id { get; set; }

        //Navigation Property
        //A ReservationTable can book one to many Tables 1-*
        public List<RestaurantTable> RestaurantTables { get; set; }

        //Navigation Property
        //A ReservationTable can only be reserved by one Reservation 1-1
        public Reservation Reservation { get; set; } = new();
    }
}
