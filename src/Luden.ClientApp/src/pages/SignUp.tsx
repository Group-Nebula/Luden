import { Endpoints } from '@/api/Endpoints'
import { IsAuthenticated } from '@/components/protected-route'
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import { useToast } from '@/components/ui/use-toast'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'

const SignUp = () => {
  const { toast } = useToast()
  const navigate = useNavigate()
  const [email, setEmail] = useState('')
  const [userName, setUserName] = useState('')
  const [password, setPassword] = useState('')

  useEffect(() => {
    if (IsAuthenticated()) navigate('/app/home')
  }, [])

  function createUser() {
    axios
      .post(Endpoints.CreateUser, {
        userName,
        email,
        password,
      })
      .then((response) => {
        localStorage.setItem('token', response.data.token)
        toast({
          title: 'Sucess',
          description: 'You have successfully create an account!',
          variant: 'default',
        })

        navigate('/app/sign-in')
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
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
              <Link to="/sign-in">
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
            <Button className="my-6 rounded-lg" onClick={createUser}>
              Sign up
            </Button>
          </div>
        </div>
      </div>
      <div className="relative flex-col hidden p-10 bg-muted lg:flex"></div>
    </div>
  )
}

export default SignUp
