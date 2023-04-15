namespace PersonalFinalProject.Data
{
    public class Sitting
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
        public string Name { get; set; }

        public int Capacity{ get; set; }
        public string Active { get; set; }
        public List<SittingType> SittingTypes { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<Reservation> Reservations { get; set; } = new();
    }
}
