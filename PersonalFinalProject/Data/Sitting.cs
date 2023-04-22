using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class Sitting
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }
        public string Name { get; set; }
        [Required]
        public int Capacity{ get; set; }

        [Required]
        public Boolean Active { get; set; }

        //Navigation Property
        //A seating belongs to one and ONLY one SittingType
        public SittingType SittingType { get; set; }
        //Navigation Property
        //A seating can be booked by 0-* reservations
        public List<Reservation> Reservations { get; set; } = new();
    }
}
