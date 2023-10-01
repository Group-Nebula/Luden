using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class CharacterSkill : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Base Entity Properties
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Properties
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public int Value { get; set; }

        //Relationships
        public Character Character { get; set; }
        public Skill Skill { get; set; }
    }
}
