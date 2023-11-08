import { Input } from '@/components/ui/input'
import { Separator } from '@/components/ui/separator'

const ProfileSettings = () => (
  <>
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
    {/* <div className="mb-3 mt-3">
      <p className="text-xl mb-3">Email</p>
      <Input className="rounded"></Input>
      <p className="text-muted-foreground">
        You can manage your verified Email Here.
      </p>
    </div> */}
  </>
)

export default ProfileSettings
