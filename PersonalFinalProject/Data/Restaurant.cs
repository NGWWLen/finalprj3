using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        //Navigation Property
        //A restaurant can have one to many areas 1-*
        public List<Area> Areas { get; set; } = new();

        //Not necessary
        //public List<Sitting>sittings { get; set; } = new();
    }
}
