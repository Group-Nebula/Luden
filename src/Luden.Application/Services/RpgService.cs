using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.Rpg;
using Luden.Application.Models.Responses.Rpg;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Exceptions.Rpg;
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

        public async Task Create(CreateRpgReq request)
        {
            var rpg = new Rpg
            {
                Name = request.Name,
                Description = request.Description,
                MasterId = request.MasterId,
                ImageUrl = request.ImageUrl,
                RpgDate = request.RpgDate,
                RpgSystemId = request.RpgSystemId,
            };

            rpg = await _unitOfWork.Repository<Rpg>().AddAsync(rpg);
            await _unitOfWork.SaveChangesAsync();

            foreach (var playerId in request.RpgPlayers)
            {
                var rpgUser = new RpgPlayer
                {
                    RpgId = rpg.Id,
                    PlayerId = playerId,
                };

                await _unitOfWork.Repository<RpgPlayer>().AddAsync(rpgUser);
            }
        }
        public async Task Update(UpdateRpgReq request)
        {
            var rpg = await _unitOfWork.Repository<Rpg>().GetByIdAsync(request.Id) ?? throw new RpgNotFoundException();

            rpg.Name = request.Name ?? rpg.Description;
            rpg.Description = request.Description ?? rpg.Description;
            rpg.ImageUrl = request.ImageUrl ?? rpg.ImageUrl;
            rpg.RpgDate = request.RpgDate ?? rpg.RpgDate;

            _unitOfWork.Repository<Rpg>().Update(rpg);

            var rpgPlayersSpec = RpgPlayerSpecifications.GetByRpgIdSpec(rpg.Id);
            var rpgPlayers = await _unitOfWork.Repository<RpgPlayer>().ListAsync(rpgPlayersSpec);

            _unitOfWork.Repository<RpgPlayer>().DeleteRange(rpgPlayers);

            foreach (var playerId in request.RpgPlayers)
            {
                var rpgUser = new RpgPlayer
                {
                    RpgId = rpg.Id,
                    PlayerId = playerId,
                };

                await _unitOfWork.Repository<RpgPlayer>().AddAsync(rpgUser);
            }
        }

        public async Task Delete(Guid rpgId)
        {
            var rpg = await _unitOfWork.Repository<Rpg>().GetByIdAsync(rpgId) ?? throw new RpgNotFoundException();

            rpg.IsDeleted = true;

            _unitOfWork.Repository<Rpg>().Update(rpg);
        }

        public async Task<GetAllRpgsRes> GetAllActive(string? rpgName)
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
