import { Route, Routes } from 'react-router-dom'
import LandingPage from './pages/landing-page'
import Navigation from './pages/navigation'
import SignUp from './pages/SignUp'
import SignIn from './pages/SignIn'

const App = () => {
  return (
    <Routes>
      <Route path="/">
        <Route index element={<LandingPage />} />
        <Route path="sign-in" element={<SignIn />} />
        <Route path="sign-up" element={<SignUp />} />
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
      </Route>
    </Routes>
  )
}

export default App
