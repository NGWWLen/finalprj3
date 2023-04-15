namespace PersonalFinalProject.Data
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Restaurant Restaurant { get; set; }

        public List<RestaurantTable> RestaurantsTables { get; set; } = new();

    }
}
