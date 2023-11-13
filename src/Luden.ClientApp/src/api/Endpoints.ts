const BaseUrl = 'https://localhost:7118'

export enum Endpoints {
  CreateUser = BaseUrl + '/api/user/create',
  ValidateUser = BaseUrl + '/api/User/Validate',
  UpdateUser = BaseUrl + '/api/User/Update',
}
