import CreateAccount from '@/pages/create-account'
import LandingPage from '@/pages/landing-page'
import LoginPage from '@/pages/login'
import { RouteObject } from 'react-router-dom'

const routes: RouteObject[] = [
  {
    path: '/',
    element: <LandingPage />,
  },
  {
    path: '/create-account',
    element: <CreateAccount />,
  },
  {
    path: '/login',
    element: <LoginPage />,
  },
]

export default routes
