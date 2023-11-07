import { Endpoints } from '@/api/Endpoints'
import HorizontalList from '@/components/horizontal-list'
import { Button } from '@/components/ui/button'
import { DropdownMenuSeparator } from '@/components/ui/dropdown-menu'
import { useToast } from '@/components/ui/use-toast'
import axios from 'axios'
import { useEffect, useState } from 'react'

const Home = () => {
  const { toast } = useToast()

  interface ListItem {
    id: number
    name: string
    description: string
    image: string
  }

  const [characters, setCharacters] = useState<ListItem[]>([])
  const [rpgs, setRpgs] = useState<ListItem[]>([])

  const getAllCharacters = () => {
    axios
      .get(Endpoints.GetAllCharacter)
      .then((response) => {
        setCharacters(response.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  }

  const getAllRpgs = () => {
    axios
      .get(Endpoints.GetAllRpg)
      .then((response) => {
        setRpgs(response.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  }

  useEffect(() => {
    getAllCharacters()
    getAllRpgs()
  }, [characters, rpgs])

  return (
    <div className="h-full w-full justify-center">
      {characters.length > 0 && (
        <div>
          <h2 className="text-2xl font-semibold tracking-tight">Characters</h2>
          <p className="text-sm text-muted-foreground">
            The most recent Characters.
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
      {
        characters.length < 0 && rpgs.length < 0 && (

        )
      }
    </div>
  )
}

export default Home
