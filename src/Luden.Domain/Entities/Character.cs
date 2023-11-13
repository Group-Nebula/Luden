using Luden.Domain.Core.Models;
using Luden.Domain.Enums;

namespace Luden.Domain.Entities
{
    public class Character : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Base Entity Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }

        //Properties
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public CharacterStatus Status { get; set; }

        //Relationships
        public User User { get; set; }
        public IEnumerable<CharacterSkill> CharacterSkills { get; set; }
    }
}
