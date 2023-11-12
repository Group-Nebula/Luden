const BaseUrl = 'https://localhost:7118'

export enum Endpoints {
  // [User]
  CreateUser = BaseUrl + '/api/user/Create',
  ValidateUser = BaseUrl + '/api/User/Validate',
  GetAllUsers = BaseUrl + '/api/User/GetAll',

  // [Character]
  GetAllCharacters = BaseUrl + '/api/Character/GetAllActive',
  GetAllCharactersByUserId = BaseUrl + '/api/Character/GetAllByUserId',

  // [Rpg]
  GetAllRpgs = BaseUrl + '/api/Rpg/GetAllActive',
  GetAllRpgsByUserId = BaseUrl + '/api/Rpg/GetAllByUserId',
}
