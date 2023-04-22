using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string LastName { get; set; }
  
        [Display(Name = "Phone Number")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(20)]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[#$^+=!*()@%&]).{6,20}$")]
        public string Password { get; set; }

        //Navigation Property
        //A user can have 0-* reservations
        public List<Reservation>? Reservations { get; set; }

        //Navigation Property
        //A user can have one and ONLY one UserType
        public UserType UserType { get; set; }

    }
}
