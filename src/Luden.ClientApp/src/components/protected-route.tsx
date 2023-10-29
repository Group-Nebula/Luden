import { Navigate } from 'react-router-dom'
const ProtectedRoute = ({ children }) => {
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

export default ProtectedRoute
