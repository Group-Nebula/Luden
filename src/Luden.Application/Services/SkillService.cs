using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Responses;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Specifications;

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

        public async Task<IEnumerable<NameIdRes>> GetAllBySystemId(Guid rpgSystemId)
        {
            var GetAllBySystemIdSpec = SkillSpecifications.GetAllBySystemId(rpgSystemId);

            var skills = await _unitOfWork.Repository<Skill>().ListAsync(GetAllBySystemIdSpec);

            return skills.Select(x => new NameIdRes(x.Id, x.Name));
        }
    }
}
