using GamesBasePrototype.API.Entities;

namespace GamesBasePrototype.API.Models
{
    public class GamesBaseInputModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
