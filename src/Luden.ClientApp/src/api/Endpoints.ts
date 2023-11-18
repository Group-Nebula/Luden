const BaseUrl = 'https://localhost:7118'

export enum Endpoints {
  // [Character]
  CreateCharacter = BaseUrl + '/api/Character/Create',
  UpdateCharacter = BaseUrl + '/api/Character/Update',
  DeleteCharacter = BaseUrl + '/api/Character/Delete',
  GetCharacterById = BaseUrl + '/api/Character/GetById',
  ListAllCharacter = BaseUrl + '/api/Character/GetAllNameId',
  GetAllCharacters = BaseUrl + '/api/Character/GetAllActive',
  GetAllCharactersByUserId = BaseUrl + '/api/Character/GetAllByUserId',
  //
  // [Rpg]
  CreateRpg = BaseUrl + '/api/Rpg/Create',
  UpdateRpg = BaseUrl + '/api/Rpg/Update',
  DeleteRpg = BaseUrl + '/api/Rpg/Delete',
  GetAllRpgs = BaseUrl + '/api/Rpg/GetAll',
  GetAllRpgsByUserId = BaseUrl + '/api/Rpg/GetAllByUserId',

  // [Rpg Systems]
  CreateRpgSystem = BaseUrl + '/api/RpgSystem/Create',
  UpdateRpgSystem = BaseUrl + '/api/RpgSystem/Update',
  DeleteRpgSystem = BaseUrl + '/api/RpgSystem/Delete',
  GetRpgSystem = BaseUrl + '/api/RpgSystem/GetById',
  ListAllRpgSystem = BaseUrl + '/api/RpgSystem/GetAllNameId',
  GetAllRpgSystems = BaseUrl + '/api/RpgSystem/GetAll',

  // [User]
  CreateUser = BaseUrl + '/api/User/Create',
  ValidateUser = BaseUrl + '/api/User/Validate',
  GetAllUsers = BaseUrl + '/api/User/GetAll',
  UpdateUser = BaseUrl + '/api/User/Update',
}
