using System.ComponentModel.DataAnnotations;

namespace PersonalFinalProject.Data
{
    public class SittingType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        //A SittingType defines 0-* Sittings
        public List<Sitting> Sittings { get; set; } = new List<Sitting>();
    }
}
