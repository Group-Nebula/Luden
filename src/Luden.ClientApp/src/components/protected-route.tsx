import { Navigate } from 'react-router-dom'
import { ReactNode } from 'react'

interface ProtectedRouteProps {
  children: ReactNode
}
const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
  if (
    localStorage.getItem('token') === null ||
    localStorage.getItem('token') === 'undefined' ||
    localStorage.getItem('token') === undefined
  ) {
    return <Navigate to="/" />
  } else {
    return children
  }
}

const IsAuthenticated = () => {
  if (
    localStorage.getItem('token') === null ||
    localStorage.getItem('token') === 'undefined' ||
    localStorage.getItem('token') === undefined
  ) {
    return false
  } else {
    return true
  }
}

export default ProtectedRoute
export { IsAuthenticated }
