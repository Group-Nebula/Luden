import { Endpoints } from '@/api/Endpoints'
import { Input } from '@/components/ui/input'
import { Separator } from '@/components/ui/separator'
import { useToast } from '@/components/ui/use-toast'
import { useState } from 'react'
import axios from 'axios'
import { Button } from '@/components/ui/button'

const ProfileSettings = () => {
  const { toast } = useToast()

  const [userName, setUserName] = useState('')

  function updateUser() {
    axios
      .post(Endpoints.UpdateUser, {
        userName,
      })
      .then((response) => {
        localStorage.setItem('token', response.data.token)
        toast({
          title: 'Sucess',
          description: 'Username changed successfully!',
          variant: 'default',
        })
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
    <div>
      <div className="mb-3">
        <h1 className="text-2xl">Profile</h1>
        <p className="text-muted-foreground">Manage your profile</p>
      </div>
      <Separator />
      <div className="mb-3 mt-8">
        <p className="text-xl mb-3">UserName</p>
        <Input className="rounded"></Input>
        <p className="text-muted-foreground">
          This is the name that everyone can see. Show Them your best NickName!
        </p>
      </div>
      <Button className="my-6 rounded-lg" variant="ghost" onClick={updateUser}>
        Change
      </Button>
    </div>
  )
}

export default ProfileSettings
