using GamesBasePrototype.API.Entities;

namespace GamesBasePrototype.API.Models
{
    public class GamesBaseViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<GamesBaseDevViewModel> Devs { get; set; }
    }

    public class GamesBaseDevViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public string SteamProfile { get; set; }
    }
}
