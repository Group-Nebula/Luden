using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class RpgSession : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid RpgId { get; set; }
        public Guid SessionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset SessionDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        //Relationships
        public Rpg Rpg { get; set; }
        public Session Session { get; set; }
    }
}
