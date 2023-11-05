import HorizontalList from '@/components/horizontal-list'
import { Button } from '@/components/ui/button'
import { DropdownMenuSeparator } from '@/components/ui/dropdown-menu'

const Home = () => {
  return (
    <div className="h-full w-full">
      <Button variant="outline" size="sm" className="my-2 w-half ">
        + Add Character
      </Button>
      <h2 className="text-2xl font-semibold tracking-tight">Rooms</h2>
      <p className="text-sm text-muted-foreground">Recent rooms you are in.</p>
      <DropdownMenuSeparator />
      <HorizontalList />
      <h2 className="text-2xl font-semibold tracking-tight">Characters</h2>
      <p className="text-sm text-muted-foreground">
        The most recent Characters.
      </p>
      <DropdownMenuSeparator />
      <HorizontalList />
    </div>
  )
}

export default Home
