import { Endpoints } from '@/api/Endpoints'
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import { useToast } from '@/components/ui/use-toast'
import axios from 'axios'
import { useState } from 'react'
import { Link } from 'react-router-dom'

const CreateAccount = () => {
  const { toast } = useToast()

  const [email, setEmail] = useState('')
  const [userName, setUserName] = useState('')
  const [password, setPassword] = useState('')

  function signUp() {
    axios
      .post(Endpoints.CreateUser, {
        userName,
        email,
        password,
      })
      .then(() => {
        toast({
          title: 'Sucess',
          description: 'You have successfully create an account!',
          variant: 'default',
        })
      })
      .catch(() => {
        toast({
          title: 'Something went wrong',
          description: 'Please try again later.',
          variant: 'destructive',
        })
      })
  }

  return (
    <div className="bg-background text-foreground container relative h-[100vh] flex-col md:grid lg:max-w-none lg:grid-cols-2 lg:px-0">
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
              <Input
                onChange={(e) => {
                  setUserName(e.target.value)
                }}
              ></Input>
            </p>
            <p className="font-semibold text-start">
              Email:
              <Input
                type="email"
                onChange={(e) => {
                  setEmail(e.target.value)
                }}
              ></Input>
            </p>
            <p className="font-semibold text-start">
              Password:
              <Input
                type="password"
                onChange={(e) => {
                  setPassword(e.target.value)
                }}
              ></Input>
            </p>
            <Button className="my-6 rounded-lg" onClick={signUp}>
              Sign up
            </Button>
          </div>
        </div>
      </div>
      <div className="relative flex-col hidden p-10 bg-muted lg:flex"></div>
    </div>
  )
}

export default CreateAccount
