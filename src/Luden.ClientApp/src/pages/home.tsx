import { Endpoints } from '@/api/Endpoints'
import { HorizontalList } from '@/components/list'
import { NoDataAnimation } from '@/components/lottie-animations'
import { Button } from '@/components/ui/button'
import { DropdownMenuSeparator } from '@/components/ui/dropdown-menu'
import { useToast } from '@/components/ui/use-toast'
import { parseJwt } from '@/utils/token'
import axios from 'axios'
import { useEffect, useState } from 'react'
import { useEventCallback } from 'usehooks-ts'

const Home = () => {
  const { toast } = useToast()

  interface ListItem {
    id: string
    name: string
    description: string
    imageUrl: string
  }

  const [characters, setCharacters] = useState<ListItem[]>([])
  const [rpgs, setRpgs] = useState<ListItem[]>([])

  const userId = (parseJwt() as { unique_name: string }).unique_name

  const getAllCharacters = useEventCallback(() => {
    axios
      .get(Endpoints.GetAllCharactersByUserId + `?userId=${userId}`)
      .then((response) => {
        setCharacters(response.data.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  })

  const getAllRpgs = useEventCallback(() => {
    axios
      .get(Endpoints.GetAllRpgsByUserId + `?userId=${userId}`)
      .then((response) => {
        setRpgs(response.data.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  })

  useEffect(() => {
    getAllCharacters()
    getAllRpgs()
  }, [])

  return (
    <div className="w-full justify-center">
      {characters.length > 0 && (
        <div>
          <h2 className="text-2xl font-semibold tracking-tight">
            Your Characters
          </h2>
          <p className="text-sm text-muted-foreground">
            All of your Characters.
          </p>
          <DropdownMenuSeparator />
          <HorizontalList items={characters} />
        </div>
      )}
      {rpgs.length > 0 && (
        <div>
          <h2 className="text-2xl font-semibold tracking-tight">Rooms</h2>
          <p className="text-sm text-muted-foreground">
            Recent rooms you are in.
          </p>
          <DropdownMenuSeparator />
          <HorizontalList items={rpgs} />
        </div>
      )}
      {!(characters.length > 0) && !(rpgs.length > 0) && (
        <div className="flex flex-col items-center justify-center place-items-center">
          <NoDataAnimation className="md:w-[30vw] lg:w-[50vh]" />
          <p className="text-sm text-foreground text-center">
            You have no characters or rooms yet.
            <br /> <b>Start adding some!</b>
          </p>
          <Button className="mt-4">Create Character</Button>
          <Button className="mt-4" variant="outline">
            Create Room
          </Button>
        </div>
      )}
    </div>
  )
}

export default Home
