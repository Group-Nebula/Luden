using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class RpgSystem : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Base Entity Properties
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Properties
        public string Config { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //Relationships
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Rpg> Rpgs { get; set; }
    }
}
