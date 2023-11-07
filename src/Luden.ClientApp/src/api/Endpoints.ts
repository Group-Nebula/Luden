const BaseUrl = 'https://localhost:7118'

export enum Endpoints {
  // #region [User]
  CreateUser = BaseUrl + '/api/user/create',
  ValidateUser = BaseUrl + '/api/User/Validate',
  // #endregion

  // #region [Character]
  GetAllCharacter = BaseUrl + '/api/Character/GetAll',

  // #endregion
  GetAllRpg = BaseUrl + '/api/Rpg/GetAll',
}
