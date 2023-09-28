using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class RpgPlayer : BaseEntity
    {
        public Guid RpgId { get; set; }
        public Guid PlayerId { get; set; }

        //Relationships
        public Rpg Rpg { get; set; }
        public Character Player { get; set; }
    }
}
