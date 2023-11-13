import App from '@/App'
import { ModeToggle } from '@/components/ui/mode-toggle'
import { Separator } from '@/components/ui/separator'

const appearenceSettings = () => (
  <>
    <div className="mb-3">
      <h1 className="text-2xl">Appearence</h1>
      <p className="text-muted-foreground">customize it your way</p>
    </div>
    <Separator />
    <div className="mb-3 mt-8">
      <p className="text-xl mb-3">Themes</p>
      <ModeToggle />
    </div>
  </>
)

export default appearenceSettings
