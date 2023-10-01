using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class Skill : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public Guid RpgSystemId { get; set; }
        public string Name { get; set; }

        //Base Entity Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        //Relationships
        public RpgSystem RpgSystem { get; set; }
        public IEnumerable<CharacterSkill> CharacterSkills { get; set; }
    }
}
