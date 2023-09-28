using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class CharacterAttribute : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        public Guid Id { get; set; }
        public Guid CharacterId { get; set; }
        public Guid AttributeId { get; set; }
        public int Value { get; set; }

        //Relationships
        public Character Character { get; set; }
        public System.Attribute Attribute { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
    }
}
