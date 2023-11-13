import { jwtDecode } from 'jwt-decode'

const parseJwt = () => {
  const token = localStorage.getItem('token') || ''
  return jwtDecode(token)
}

export { parseJwt }
