using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //Navigation Property
        //A UserType can define 0-* Users
        public List<User>? Users { get; set; }
    }
}
