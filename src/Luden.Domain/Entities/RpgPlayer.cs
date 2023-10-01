using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class RpgPlayer : BaseEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Properties
        public Guid RpgId { get; set; }
        public Guid PlayerId { get; set; }

        //Relationships
        public Rpg Rpg { get; set; }
        public User Player { get; set; }
    }
}
