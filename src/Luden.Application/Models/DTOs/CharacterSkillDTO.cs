namespace Luden.Application.Models.DTOs
{
    public class CharacterSkillDTO
    {
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public int Value { get; set; }
    }
}
