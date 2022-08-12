using moha.Data.enums;

namespace moha.Models
{
    public class Participent
    {
        public int ParticipentId { get; set; }
        public string name { get; set; }
        public string Description { get; set; }

        public int mosqueId { get; set; }
        public Mosque mosque { get; set; }
        public Role Roles { get; set; }


    }
}
