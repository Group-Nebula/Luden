using Luden.Domain.Core.Models;
using Luden.Domain.Enums;

namespace Luden.Domain.Entities
{
    public class Character : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Relationship Ids
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        //Character Info
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public CharacterStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        //Relationships
        public User User { get; set; }
    }
}
