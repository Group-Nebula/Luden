namespace Luden.Application.Models.Requests.Rpg
{
    public class UpdateRpgReq
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? RpgDate { get; set; }
        public Guid? RpgSystemId { get; set; }
        public Guid? MasterId { get; set; }
        public IEnumerable<Guid> RpgPlayers { get; set; }
    }
}
