using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Responses.Rpg;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Specifications;

namespace Luden.Application.Services
{
    public class RpgService : IRpgService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RpgService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllRpgsRes> GetAllActive(string rpgName)
        {
            var activeRpgsSpec = RpgSpecifications.GetAllActiveRpgsSpec(rpgName);

            var rpgs = await _unitOfWork.Repository<Rpg>().ListAsync(activeRpgsSpec);

            return new GetAllRpgsRes()
            {
                Data = rpgs.Select(x => new RpgDTO(x))
            };
        }

        public async Task<GetAllRpgsRes> GetAllActiveByUserId(Guid userId)
        {
            var activeRpgsSpec = RpgSpecifications.GetAllActiveByUserIdRpgsSpec(userId);

            var rpgs = await _unitOfWork.Repository<Rpg>().ListAsync(activeRpgsSpec);

            return new GetAllRpgsRes()
            {
                Data = rpgs.Select(x => new RpgDTO(x))
            };
        }
    }
}
