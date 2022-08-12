using System.ComponentModel.DataAnnotations;

namespace moha.Models
{
    public class Mosque
    {
        [Key]
        public int mosqueId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Info { get; set; }

        public List<Participent> Participents { get; set; } 
      

    }
}
