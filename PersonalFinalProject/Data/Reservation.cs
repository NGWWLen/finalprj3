using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Start Date/Time")]
        [Required(ErrorMessage="Please enter the starting date and time")]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [Range(1,24)]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Please enter the number of guests attending, maximum 40")]
        [Range(1, 40)]
        [Display(Name = "Guest Number")]
        public string GuestNumber { get; set; }

        [Required, MaxLength(100)]
        public string Notes { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required, minimum length of 2 and maximum length of 20"), MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required, minimum length of 2 and maximum length of 20"), MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is Required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //Navigation Property
        //One reservation may be booked by ONE guest or ONE user 0-1
        public User? User { get; set; }

        //One reservation can book ONE to MANY sittings 1-*
        public List<Sitting> Sittings { get; set; }

        //One reservation may book ONE to MANY tables 1-*
        public List<ReservationTable> ReservationTables { get; set; } = new();

        //One reservation can only have ONE status at the time 1-1
        public ReservationStatus ReservationStatus { get; set; }

        //One reservation is always originated from ONE and ONLY ONE source 1-1
        public ReservationSource ReservationSource { get; set; }

  
    }
}
