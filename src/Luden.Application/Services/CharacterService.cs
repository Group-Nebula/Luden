using Luden.Application.Interfaces;
using Luden.Application.Models.DTOs;
using Luden.Application.Models.Responses.Character;
using Luden.Domain.Core.Repositories;
using Luden.Domain.Entities;
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

        public async Task<GetAllActiveCharactersRes> GetAllActiveCharacters(string charactername)
        {
            var activeCharactersSpec = CharacterSpecifications.GetAllActiveCharactersSpec(charactername);

            var characters = await _unitOfWork.Repository<Character>().ListAsync(activeCharactersSpec);

            return new GetAllActiveCharactersRes()
            {
                Data = characters.Select(x => new CharacterDTO(x))
            };
        }
    }
}
