using PersonalFinalProject.Data;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Models
{
    public class ReservationViewModel
    {
        //To take input from webpage
        public ReservationViewModel()
        {
        }

        [Required(ErrorMessage = "Please enter the number of guests attending, maximum 40")]
        [Range(1, 40)]
        public int GuestNumber { get; set; }

        [MaxLength(100)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "First Name is Required, minimum length of 2 and maximum length of 20"), MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required, minimum length of 2 and maximum length of 20"), MinLength(2), MaxLength(20)]
        [RegularExpression(@"^[A-Za-z-']*$")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^(?:\+?(61))? ?(?:\((?=.*\)))?(0?[2-57-8])\)? ?(\d\d(?:[- ](?=\d{3})|(?!\d\d[- ]?\d[- ]))\d\d[- ]?\d[- ]?\d{3})$")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }

        public int Area { get; set; }       //Need to translate to AREA

        public int Sitting { get; set; }    //Need to translate to SITTING

        [Required(ErrorMessage = "Please enter the starting date")]
        public DateTime Start { get; set; }
        public int Duration { get; set; }   

    }
}
