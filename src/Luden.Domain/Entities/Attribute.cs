using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class Attribute : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        public Guid Id { get; set; }
        public Guid RpgSystemId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        //Relationships
        public RpgSystem RpgSystem { get; set; }
    }
}
