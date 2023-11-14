import { Separator } from '@/components/ui/separator'
import { Button } from '@/components/ui/button'
import { Link, Outlet } from 'react-router-dom'
import ProtectedRoute from '@/components/protected-route'
import { Tabs, TabsContent, TabsList, TabsTrigger } from '@radix-ui/react-tabs'
import { useMediaQuery } from 'usehooks-ts'
import { ChevronLeft } from 'lucide-react'

const Settings = () => {
  const isMobile = useMediaQuery('(max-width: 768px)')
  return (
    <ProtectedRoute>
      <Link to="/app/home">
        <Button size="icon" variant="outline" className="absolute top-5 left-5">
          <ChevronLeft />
        </Button>
      </Link>
      <div className="bg-background justify-center text-foreground lg:container h-[100vh] flex col max-w-none grid-cols-2 lg:px-0">
        <div className="flex w-[90%] mt-10 lg:p-10 rounded-lg flex-col">
          <div className="mb-3">
            <h1 className="text-2xl">Settings</h1>
            <p className="text-muted-foreground">
              Manage your sistem preferences and personalization
            </p>
          </div>
          <Separator />
          {isMobile && (
            <Tabs defaultValue="account" className="w-full">
              <TabsList className="grid w-full grid-cols-2">
                <TabsTrigger value="account">
                  <Link to="/settings/profile">
                    <Button
                      className="w-full rounded-lg justify-center"
                      variant="ghost"
                    >
                      Profile
                    </Button>
                  </Link>
                </TabsTrigger>
                <TabsTrigger value="password">
                  <Link to="/settings/appearence">
                    <Button
                      className="w-full rounded-lg justify-center"
                      variant="ghost"
                    >
                      Appearance
                    </Button>
                  </Link>
                </TabsTrigger>
              </TabsList>
              <TabsContent value="account">
                <Outlet />
              </TabsContent>
              <TabsContent value="password">
                <Outlet />
              </TabsContent>
            </Tabs>
          )}
          {!isMobile && (
            <div className="grid-cols-12 mt-10 grid max-[780px]:hidden">
              <div className="col-span-3 lg:p-5">
                <Link to="/settings/profile">
                  <Button
                    className="w-full rounded-lg justify-start"
                    variant="ghost"
                  >
                    Profile
                  </Button>
                </Link>
                <Link to="/settings/appearence">
                  <Button
                    className="w-full rounded-lg justify-start"
                    variant="ghost"
                  >
                    Appearance
                  </Button>
                </Link>
              </div>
              <div className="col-span-9 p-5">
                <Outlet />
              </div>
            </div>
          )}
        </div>
      </div>
    </ProtectedRoute>
  )
}

export default Settings
