using Luden.Domain.Core.Models;
using Luden.Domain.Enums;

namespace Luden.Domain.Entities
{
    public class User : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }

        //Base Entity Properties
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }


        //Relationships
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Rpg> Rpgs { get; set; }
        public IEnumerable<RpgPlayer> RpgPlayers { get; set; }
    }
}
