import { Navigate, Route, Routes } from 'react-router-dom'
import LandingPage from './pages/landing-page'
import SignUp from './pages/SignUp'
import SignIn from './pages/SignIn'
import Settings from './pages/settings/Settings'
import ProfileSettings from './pages/settings/profileSettings'
import AppearenceSettings from './pages/settings/appearenceSettings'
import Home from './pages/home'
import Navigation from './pages/navigation'
import ErrorPage from './pages/error-page'
import SystemsHome from './pages/systems/sytemsHome'
import CharactersHome from './pages/characters/charactersHome'

const App = () => {
  return (
    <div className="text-foreground bg-background">
      <Routes>
        <Route path="/">
          <Route index element={<LandingPage />} />
          <Route path="sign-in" element={<SignIn />} />
          <Route path="sign-up" element={<SignUp />} />
          <Route path="*" element={<ErrorPage />} />
          <Route path="app" element={<Navigation />}>
            <Route path="home" element={<Home />} />
            <Route path="characters">
              <Route index element={<CharactersHome />} />
            </Route>
            <Route path="rpg-systems">
              <Route index element={<SystemsHome />} />
            </Route>
          </Route>
          <Route path="settings" element={<Settings />}>
            <Route index element={<Navigate to="profile" replace />} />
            <Route index path="profile" element={<ProfileSettings />}></Route>
            <Route path="appearence" element={<AppearenceSettings />}></Route>
          </Route>
        </Route>
      </Routes>
    </div>
  )
}

export default App
