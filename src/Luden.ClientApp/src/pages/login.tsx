import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import { Link } from 'react-router-dom'
import { Endpoints } from '../api/Endpoints.ts'
import { useToast } from '@/components/ui/use-toast.ts'
import axios from 'axios'
import { useState } from 'react'

const LoginPage = () => {
  const { toast } = useToast()

  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  function signIn() {
    axios
      .post(Endpoints.ValidateUser, {
        email,
        password,
      })
      .then(() => {
        toast({
          title: 'Sucess',
          description: 'welcome back!',
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
              <Link to="/create-account">
                <Button variant="link" size="lg" className="rounded-lg ">
                  Sign up
                </Button>
              </Link>
            </div>
            <h1 className="text-2xl font-semibold tracking-tight ">
              Login in your account
            </h1>
            <p className="text-sm text-muted-foreground">
              Enter your email below to enter in your account
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
            <Button className="my-6 rounded-lg" onClick={signIn}>
              Sign in
            </Button>
          </div>
        </div>
      </div>
      <div className="relative flex-col hidden p-10 bg-muted lg:flex"></div>
    </div>
  )
}
export default LoginPage
