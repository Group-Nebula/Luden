import { ErrorPageAnimation } from '../components/lottie-animations'
import { Button } from '@/components/ui/button'
import { Link } from 'react-router-dom'

function ErrorPage() {
  return (
    <div className="bg-background text-foreground h-[100vh] flex flex-col items-center justify-center">
      <ErrorPageAnimation className="w-[80vw] md:w-[70vw] lg:w-[50vw]" />
      <h1 className="text-3xl mb-2 lg:text-4xl">Page not found !</h1>
      <h2>Possible Reasons:</h2>
      <ul className="list-disc mb-2">
        <li className="list-item mb-1">
          The address may have typed incorrectly;
        </li>
        <li className="list-item  mb-1">
          It may be a broken or outdated link.
        </li>
      </ul>
      <Link to="/">
        <Button size="lg" className="rounded-lg ">
          Back home
        </Button>
      </Link>
    </div>
  )
}
export default ErrorPage
