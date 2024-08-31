namespace GamesBasePrototype.API.Entities
{
    public class GamesBase
    {

        public GamesBase() 
        { 
            Devs = new List<GamesBaseDev>();
            IsDeleted = false;
        
        }
        

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<GamesBaseDev> Devs { get; set; }

        //public ICollection<DevEventSpeaker> Speakers { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime announcementDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            AnnouncementDate = announcementDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
