namespace PersonalFinalProject.Data
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        //An area can only be owned by one and only one restaurant 1-1
        public Restaurant Restaurant { get; set; }

        //Navigation Property
        //An area can have one to many tables 1-*
        public List<RestaurantTable> RestaurantTables { get; set; } = new();

    }
}
