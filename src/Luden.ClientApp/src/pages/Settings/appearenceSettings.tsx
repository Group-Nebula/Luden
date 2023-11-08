import App from '@/App'
import { Separator } from '@/components/ui/separator'
import { ThemeProvider } from '@/components/ui/theme-provider'
import { Toaster } from '@/components/ui/toaster'

const appearenceSettings = () => (
  <>
    <div className="mb-3">
      <h1 className="text-2xl">Appearence</h1>
      <p className="text-muted-foreground">customize it your way</p>
    </div>
    <Separator />
    <div className="mb-3 mt-8">
      <p className="text-xl mb-3">Themes</p>
      <ThemeProvider defaultTheme="system" storageKey="vite-ui-theme">
        <App />
        <Toaster />
      </ThemeProvider>
    </div>
  </>
)

export default appearenceSettings
