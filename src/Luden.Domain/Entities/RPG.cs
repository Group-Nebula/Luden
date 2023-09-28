using Luden.Domain.Core.Models;
namespace Luden.Domain.Entities
{
    public class Rpg : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        public Guid Id { get; set; }
        public Guid MasterId { get; set; }
        public Guid RpgSystemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RpgDate { get; set; }

        //Relationships
        public RpgSystem RpgSystem { get; set; }
        public User Master { get; set; }
        public IEnumerable<User> Players { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
