using Microsoft.EntityFrameworkCore;

namespace GamesBasePrototype.API.Entities
{
    public class GamesBaseDev
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string GameTitle { get; set; }
        public string GameDescription { get; set; }
        public string SteamProfile { get; set; }
        public Guid GamesBaseId { get; set; }
    }

}