using Luden.Domain.Entities;

namespace Luden.Application.Models.DTOs
{
    public class CharacterDTO
    {
        public CharacterDTO(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Description = character.Description;
            ImageUrl = character.ImageUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
