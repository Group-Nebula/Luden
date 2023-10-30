import { Separator } from '@/components/ui/separator'
import { Button } from '@/components/ui/button'

const UserSettings = () => {
  return (
    <>
      <div className="bg-background justify-center text-foreground container h-[100vh] flex col lg:max-w-none lg:grid-cols-2 lg:px-0">
        <div className="flex w-[90%] mt-10 border-solid border-secondary border p-10 rounded-lg flex-col">
          <div className="mb-3">
            <h1 className="text-2xl">User Settings</h1>
            <p className="text-muted-foreground">
              Manage your profile preferences and personalization
            </p>
          </div>
          <Separator />
          <div className="grid-cols-12 mt-10 grid">
            <div className="col-span-3 p-5">
              <Button
                className="w-full rounded-lg justify-start"
                variant="ghost"
              >
                Profile
              </Button>
              <Button
                className="w-full rounded-lg justify-start"
                variant="ghost"
              >
                Appearance
              </Button>
            </div>
            <div className="col-span-9 p-5"></div>
          </div>
        </div>
        <div></div>
      </div>
    </>
  )
}

export default UserSettings
