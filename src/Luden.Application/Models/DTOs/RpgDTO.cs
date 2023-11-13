using Luden.Domain.Entities;

namespace Luden.Application.Models.DTOs
{
    public class RpgDTO
    {
        public RpgDTO(Rpg rpg)
        {
            Id = rpg.Id;
            Name = rpg.Name;
            Description = rpg.Description;
            ImageUrl = rpg.ImageUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
