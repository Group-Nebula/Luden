using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.RpgSystem;
using Luden.Application.Models.Responses;
using Luden.Application.Models.Responses.RpgSystem;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Exceptions.RpgSystem;
using Luden.Domain.Specifications;

namespace Luden.Application.Services
{
    public class RpgSystemService : IRpgSystemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISkillService _skillservice;
        public RpgSystemService(IUnitOfWork unitOfWork,
                                ISkillService skillservice)
        {
            _unitOfWork = unitOfWork;
            _skillservice = skillservice;
        }

        public async Task Create(CreateRpgSystemReq request)
        {
            var rpgSystem = new RpgSystem
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Config = request.Config.ToJson(),
            };

            rpgSystem = await _unitOfWork.Repository<RpgSystem>().AddAsync(rpgSystem);

            var skills = request.Skills.Select(s => new SkillsDTO
            {
                RpgSystemId = rpgSystem.Id,
                Name = s,
            });

            await _skillservice.AddRange(skills);
        }

        public async Task Delete(Guid rpgSystemId)
        {
            var rpgSystem = await _unitOfWork.Repository<RpgSystem>().GetByIdAsync(rpgSystemId) ?? throw new RpgSystemNotFoundException();
            rpgSystem.IsDeleted = true;

            _unitOfWork.Repository<RpgSystem>().Update(rpgSystem);
        }

        public async Task<IEnumerable<GetAllRpgSystemRes>> GetAll(string rpgSystemName)
        {
            var rpgSytemSpec = RpgSystemSpecifications.GetAllActiveRpgSystemsSpec(rpgSystemName);
            var rpgSystems = await _unitOfWork.Repository<RpgSystem>().ListAsync(rpgSytemSpec);

            return rpgSystems.Select(x => new GetAllRpgSystemRes
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
        }

        public async Task<IEnumerable<NameIdRes>> GetAllNameId(string rpgSystemName)
        {
            var rpgSytemSpec = RpgSystemSpecifications.GetAllActiveRpgSystemsSpec(rpgSystemName);
            var rpgSystems = await _unitOfWork.Repository<RpgSystem>().ListAsync(rpgSytemSpec);

            return rpgSystems.Select(x => new NameIdRes(x.Id, x.Name));
        }

        public async Task<RpgSystemDTO> GetById(Guid rpgSystemId)
        {
            var rpgSystem = await _unitOfWork.Repository<RpgSystem>().GetByIdAsync(rpgSystemId) ?? throw new RpgSystemNotFoundException();

            return new RpgSystemDTO(rpgSystem);
        }

        public async Task Update(UpdateRpgSystemReq request)
        {
            var rpgSystem = await _unitOfWork.Repository<RpgSystem>().GetByIdAsync(request.Id) ?? throw new RpgSystemNotFoundException();

            rpgSystem.Name = request.Name ?? rpgSystem.Name;
            rpgSystem.Description = request.Description ?? rpgSystem.Description;
            rpgSystem.Config = request.Config == null ? rpgSystem.Config : request.Config.ToJson();

            _unitOfWork.Repository<RpgSystem>().Update(rpgSystem);
        }
    }
}
