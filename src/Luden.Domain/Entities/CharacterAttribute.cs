using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class CharacterAttribute : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
