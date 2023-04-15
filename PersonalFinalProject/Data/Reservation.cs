namespace PersonalFinalProject.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public string Guest { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public Sitting Sitting { get; set; }
        public ReservationSource ReservationSource { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public List<ReservationTable> reservationTables { get; set; } = new();
        
        public int NumberOfPeople { get; internal set; }
    }
}
