import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import { Link } from 'react-router-dom'

const CreateAccount = () => {
  return (
    <div className="bg-background text-foreground container relative h-[100vh] flex-col md:grid lg:max-w-none lg:grid-cols-3 lg:px-0">
      <div className="lg:p-10">
        <div className="mx-auto flex w-full flex-col space-y-6 sm:w-[350px] p-1">
          <div className="flex flex-col p-1 space-y-2 text-center">
            <div className="w-full text-end">
              <Link to="/login">
                <Button variant="link" size="xlg">
                  Sign in
                </Button>
              </Link>
            </div>
            <h1 className="text-2xl font-semibold tracking-tight ">
              Create an account
            </h1>
            <p className="text-sm text-muted-foreground">
              Enter your email below to create your account
            </p>
            <p className="font-semibold text-start">
              Username:
              <Input id="username"></Input>
            </p>
            <p className="font-semibold text-start">
              Email:
              <Input id="email" type="email"></Input>
            </p>
            <p className="font-semibold text-start">
              Password:
              <Input id="password" type="password"></Input>
            </p>
            <Button className="my-6 rounded-lg">Sign up</Button>
          </div>
        </div>
      </div>
      <div className="relative flex-col hidden col-span-2 p-10 bg-muted lg:flex"></div>
    </div>
  )
}

export default CreateAccount
