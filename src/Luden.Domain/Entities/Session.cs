using Luden.Domain.Core.Models;

namespace Luden.Domain.Entities
{
    public class Session : BaseEntity
    {
        //Primary Key
        public Guid Id { get; set; }

        //Relationships
        public IEnumerable<RpgSession> RpgSessions { get; set; }
    }
}
