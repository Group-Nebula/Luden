using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;

namespace Luden.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddRange(IEnumerable<SkillsDTO> skillsDTO)
        {
            var Skills = new List<Skill>();

            foreach (var skill in skillsDTO)
            {
                Skills.Add(new Skill
                {
                    RpgSystemId = skill.RpgSystemId,
                    Name = skill.Name,
                });
            }

            await _unitOfWork.Repository<Skill>().AddRangeAsync(Skills);
        }
    }
}
