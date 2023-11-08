import ErrorPageAnimation from '@/components/LottieAnimations/ErrorPageAnimation'
import { Button } from '@/components/ui/button'
import { Link } from 'react-router-dom'

function ErrorPage() {
  return (
    <div className="bg-background text-foreground h-[100vh]">
      <div className="flex flex-col items-center">
        <ErrorPageAnimation />
      </div>
      <div className=" flex flex-col items-center">
        {/* <h1 className="text-3xl mb-2 lg:text-4xl">Hello adventurer !</h1>
        <h2 className="text-lg mb-4">
          It seems like you got lost on your journey
        </h2> */}
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
    </div>
  )
}
export default ErrorPage
