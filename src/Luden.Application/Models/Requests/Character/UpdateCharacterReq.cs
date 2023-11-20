using Luden.Domain.Enums;

namespace Luden.Application.Models.Requests.Character
{
    public class UpdateCharacterReq
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public CharacterStatus? Status { get; set; }
        public IEnumerable<KeyValuePair<Guid, int>> Skills { get; set; }
    }
}
