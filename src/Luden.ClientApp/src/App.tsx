import { Route, Routes } from 'react-router-dom'
import LandingPage from './pages/landing-page'
import Navigation from './pages/navigation'
import SignUp from './pages/SignUp'
import SignIn from './pages/SignIn'
import Settings from './pages/Settings/Settings'
import ProfileSettings from './pages/Settings/profileSettings'
import AppearenceSettings from './pages/Settings/appearenceSettings'

const App = () => {
  return (
    <Routes>
      <Route path="/">
        <Route index element={<LandingPage />} />
        <Route path="login" element={<SignIn />} />
        <Route path="create-account" element={<SignUp />} />
        <Route path="*" element={<h1>404</h1>} />
        <Route path="app" element={<Navigation />}>
          <Route
            path="home"
            element={
              <section className="section">
                <h2>home page</h2>
              </section>
            }
          />
        </Route>
        <Route path="settings" element={<Settings />}>
          <Route index element={<ProfileSettings />}></Route>
          <Route path="profile" element={<ProfileSettings />}></Route>
          <Route path="appearence" element={<AppearenceSettings />}></Route>
        </Route>
      </Route>
    </Routes>
  )
}

export default App
