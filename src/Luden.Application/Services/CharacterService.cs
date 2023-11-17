using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Requests.Character;
using Luden.Application.Models.Responses;
using Luden.Application.Models.Responses.Character;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
using Luden.Domain.Exceptions.Character;
using Luden.Domain.Specifications;

namespace Luden.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICharacterSkillService _characterSkillService;

        public CharacterService(IUnitOfWork unitOfWork,
                                ICharacterSkillService characterSkillService)
        {
            _unitOfWork = unitOfWork;
            _characterSkillService = characterSkillService;
        }

        public async Task CreateCharacter(CreateCharacterReq request)
        {
            var character = new Character
            {
                UserId = request.UserId,
                Name = request.Name,
                BirthDate = request.BirthDate,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Status = Domain.Enums.CharacterStatus.Normal
            };

            character = await _unitOfWork.Repository<Character>().AddAsync(character);

            var characterSkills = request.Skills.Select(x => new CharacterSkill
            {
                CharacterId = character.Id,
                SkillId = x.Key,
                Value = x.Value
            });

            await _characterSkillService.AddRange(characterSkills);
        }

        public async Task DeleteCharacter(Guid characterId)
        {
            var character = await _unitOfWork.Repository<Character>().GetByIdAsync(characterId)
                            ?? throw new CharacterNotFoundException();

            character.IsDeleted = true;

            _unitOfWork.Repository<Character>().Update(character);
        }

        public async Task<GetAllCharactersRes> GetAllActiveCharacters(string? characterName)
        {
            var activeCharactersSpec = CharacterSpecifications.GetAllActiveCharactersSpec(characterName);

            var characters = await _unitOfWork.Repository<Character>().ListAsync(activeCharactersSpec);

            return new GetAllCharactersRes()
            {
                Data = characters.Select(x => new CharacterDTO(x))
            };
        }
        public async Task<GetAllCharactersRes> GetAllActiveCharactersByUserId(Guid userId)
        {
            var activeCharactersSpec = CharacterSpecifications.GetAllActiveCharactersByUserIdSpec(userId);

            var characters = await _unitOfWork.Repository<Character>().ListAsync(activeCharactersSpec);

            return new GetAllCharactersRes()
            {
                Data = characters.Select(x => new CharacterDTO(x))
            };
        }

        public async Task<IEnumerable<NameIdRes>> GetAllCharactersNameId(string? characterName)
        {
            var activeCharactersSpec = CharacterSpecifications.GetAllActiveCharactersSpec(characterName);

            var characters = await _unitOfWork.Repository<Character>().ListAsync(activeCharactersSpec);

            return characters.Select(x => new NameIdRes(x.Id, x.Name));

        }

        public async Task<CharacterDTO> GetCharacterById(Guid characterId)
        {
            var character = await _unitOfWork.Repository<Character>().GetByIdAsync(characterId);

            return character == null ? throw new CharacterNotFoundException() : new CharacterDTO(character);
        }

        public async Task UpdateCharacter(UpdateCharacterReq request)
        {
            //update the character
            var character = await _unitOfWork.Repository<Character>().GetByIdAsync(request.Id)
                            ?? throw new CharacterNotFoundException();

            character.Name = request.Name ?? character.Name;
            character.BirthDate = request.BirthDate ?? character.BirthDate;
            character.Description = request.Description ?? character.Description;
            character.ImageUrl = request.ImageUrl ?? character.ImageUrl;
            character.Status = request.Status ?? character.Status;

            _unitOfWork.Repository<Character>().Update(character);

            var characterSkills = request.Skills.Select(x => new CharacterSkillDTO
            {
                CharacterId = character.Id,
                SkillId = x.Key,
                Value = x.Value
            });

            await _characterSkillService.UpdateRange(characterSkills);
        }
    }
}
