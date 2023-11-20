using Luden.Domain.Entities;

namespace Luden.Application.Models.DTOs
{
    public class RpgSystemDTO
    {
        public RpgSystemDTO(RpgSystem rpgSystem)
        {
            Id = rpgSystem.Id;
            Name = rpgSystem.Name;
            Description = rpgSystem.Description;
            Config = RpgSystemConfigDTO.FromJson(rpgSystem.Config);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RpgSystemConfigDTO Config { get; set; }
    }
}
