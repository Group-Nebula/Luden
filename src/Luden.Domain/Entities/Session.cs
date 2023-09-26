namespace Luden.Domain.Entities
{
    public class Session
    {
        //Session Info
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateRPG { get; set; }
        public DateTime DateSession { get; set; }

        //Relationships Ids
        public Guid Id { get; set; }
        public Guid MasterId { get; set; }

        //Relationships
        public RPGSystem System { get; set; }
        public User master { get; set; }
        public IEnumerable<User> Players { get; set; }
    }
}
