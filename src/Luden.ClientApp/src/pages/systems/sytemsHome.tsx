import { Endpoints } from '@/api/Endpoints'
import { GridList } from '@/components/list'
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import { Separator } from '@/components/ui/separator'
import { toast } from '@/components/ui/use-toast'
import axios from 'axios'
import { Search, PlusCircle } from 'lucide-react'
import { useState } from 'react'
import { useMediaQuery } from 'usehooks-ts'

const SystemsHome = () => {
  const isMobile = useMediaQuery('(max-width: 768px)')
  const [systemsName, setSystemsName] = useState('')
  const [systems, setSystems] = useState([])

  const GetSystems = () => {
    axios
      .get(Endpoints.GetAllCharacters + `?characterName=${systemsName}`)
      .then((response) => {
        setSystems(response.data.data)
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
    <>
      <div>
        <h1 className="text-2xl">RPG Systems</h1>
        <p className="text-muted-foreground">Find or add a new RPG system</p>
      </div>
      <Separator className="my-3" />
      <div className="flex col items-center justify-center h-full w-full">
        <div className="relative w-[85%]">
          <Button
            variant="link"
            className="absolute inset-y-0 right-0 flex items-center pr-3"
            onClick={GetSystems}
          >
            <Search className="text-input" />
          </Button>
          <Input
            placeholder="Search for a system"
            onChange={(e) => {
              setSystemsName(e.target.value)
            }}
          />
        </div>
        <Button className="mx-3 w-[15%] p-0">
          <PlusCircle />
          {!isMobile && <p className="text-sm ms-1">Add</p>}
        </Button>
      </div>
      <GridList items={systems} />
    </>
  )
}

export default SystemsHome
