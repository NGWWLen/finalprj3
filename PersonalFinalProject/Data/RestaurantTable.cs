namespace PersonalFinalProject.Data
{
    public class RestaurantTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }
        public List<ReservationTable> ReservationTables { get; set; } = new();
    }
}
