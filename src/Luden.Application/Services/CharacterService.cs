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

        public CharacterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateCharacter(CreateCharacterReq request)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCharacter(Guid characterId)
        {
            var characterSpec = CharacterSpecifications.GetById(characterId);
            var character = await _unitOfWork.Repository<Character>().FirstOrDefaultAsync(characterSpec)
                            ?? throw new CharacterNotFoundException();

            character.IsDeleted = true;

            _unitOfWork.Repository<Character>().Update(character);
        }

        public async Task<GetAllCharactersRes> GetAllActiveCharacters(string characterName)
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
            var characterSpec = CharacterSpecifications.GetById(characterId);

            var character = await _unitOfWork.Repository<Character>().FirstOrDefaultAsync(characterSpec);

            return character == null ? throw new CharacterNotFoundException() : new CharacterDTO(character);
        }

        public Task UpdateCharacter(UpdateCharacterReq request)
        {
            throw new NotImplementedException();
        }
    }
}
