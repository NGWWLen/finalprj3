namespace PersonalFinalProject.Data
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Area> Areas { get; set; } = new();
        public List<Sitting>sittings { get; set; } = new();
    }
}
