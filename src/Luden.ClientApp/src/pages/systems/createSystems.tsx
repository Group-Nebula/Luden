import ProtectedRoute from '@/components/protected-route'
import RpgSystemsForm from '@/components/rpgSystemsForm'
import { Button } from '@/components/ui/button'
import { ScrollArea } from '@/components/ui/scroll-area'
import { Separator } from '@/components/ui/separator'
import { ChevronLeft } from 'lucide-react'
import { useNavigate } from 'react-router-dom'

const CreateSystem = () => {
  const navigate = useNavigate()

  return (
    <ScrollArea className="h-[100vh] w-[100vw] p-5">
      <ProtectedRoute>
        <Button
          size="icon"
          variant="outline"
          onClick={() => {
            navigate(-1)
          }}
        >
          <ChevronLeft />
        </Button>

        <div className="bg-background justify-center text-foreground lg:container h-full flex col max-w-none grid-cols-2 lg:px-0 font-normal">
          <div className="flex w-full lg:p-10 rounded-lg flex-col">
            <div className="mb-3">
              <h1 className="text-2xl">Create a Rpg System</h1>
              <p className="text-muted-foreground">
                Manage your sistem preferences and personalization
              </p>
            </div>
            <Separator />
            <div className="m-3 w-full">
              <RpgSystemsForm />
            </div>
          </div>
        </div>
      </ProtectedRoute>
    </ScrollArea>
  )
}

export default CreateSystem
