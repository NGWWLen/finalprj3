using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        //Navigation Property
        public List<Reservation>? Reservations { get; set; }

    }
}
