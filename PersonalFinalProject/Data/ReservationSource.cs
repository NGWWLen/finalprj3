﻿namespace PersonalFinalProject.Data
{
    public class ReservationSource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        //One ReservationSource can be used by zero to many reservation 0-*
        public List<Reservation>? Reservations { get; set; }
    }
}
