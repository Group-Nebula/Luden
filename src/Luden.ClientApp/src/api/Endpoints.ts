const BaseUrl = 'https://localhost:7118'

export enum Endpoints {
  // [User]
  CreateUser = BaseUrl + '/api/user/create',
  ValidateUser = BaseUrl + '/api/User/Validate',

  // [Character]
  GetAllCharacter = BaseUrl + '/api/Character/GetAll',

  // [Rpg]
  GetAllRpg = BaseUrl + '/api/Rpg/GetAll',
}
