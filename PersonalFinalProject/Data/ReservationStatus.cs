namespace PersonalFinalProject.Data
{
    public class ReservationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        //A status can be used by ZERO to MANY reservations
        public List<Reservation>? Reservations { get; set; }
    }
}
