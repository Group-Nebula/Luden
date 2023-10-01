using Luden.Domain.Core.Models;
namespace Luden.Domain.Entities
{
    public class Rpg : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public Guid MasterId { get; set; }
        public Guid RpgSystemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RpgDate { get; set; }

        //Base Entity Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        //Relationships
        public RpgSystem RpgSystem { get; set; }
        public User Master { get; set; }
        public IEnumerable<RpgSession> RpgSessions { get; set; }
        public IEnumerable<RpgPlayer> RpgPlayers { get; set; }
    }
}
