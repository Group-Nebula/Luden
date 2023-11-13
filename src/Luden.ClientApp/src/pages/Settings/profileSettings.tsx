import { Endpoints } from '@/api/Endpoints'
import { Input } from '@/components/ui/input'
import { Separator } from '@/components/ui/separator'
import { useToast } from '@/components/ui/use-toast'
import { useState } from 'react'
import axios from 'axios'
import { parseJwt } from '@/utils/token'
import { Button } from '@/components/ui/button'

const ProfileSettings = () => {
  const { toast } = useToast()

  const [userName, setUserName] = useState('')
  const Id = (parseJwt() as { unique_name: string }).unique_name
  function updateUser() {
    axios
      .put(Endpoints.UpdateUser, {
        Id,
        userName,
      })
      .then((response) => {
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
        <Input
          className="rounded"
          onChange={(e) => {
            setUserName(e.target.value)
          }}
        ></Input>
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
