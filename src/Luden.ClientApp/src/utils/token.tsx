import { jwtDecode } from 'jwt-decode'

const parseJwt = (token: string) => {
  return jwtDecode(token)
}

export { parseJwt }
