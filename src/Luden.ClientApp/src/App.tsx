import { useRoutes } from 'react-router-dom'
import routes from './routes/route'

const App = () => {
  const content = useRoutes(routes)
  return content
}

export default App
