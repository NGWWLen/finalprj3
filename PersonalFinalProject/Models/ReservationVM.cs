namespace PersonalFinalProject.Models
{
    public class ReservationVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int GuestNum { get; set; }

    }
}
