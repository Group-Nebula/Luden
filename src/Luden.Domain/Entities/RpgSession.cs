using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class RpgSession : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public Guid RpgId { get; set; }
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public string SessionNotes { get; set; }
        public DateTime SessionDate { get; set; }

        //Base Entity Properties
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Relationships
        public Rpg Rpg { get; set; }
        public Session Session { get; set; }
    }
}
