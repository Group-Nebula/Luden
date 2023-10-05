using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class User : BaseEntity, IAuditableEntity, ISoftDeleteEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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
