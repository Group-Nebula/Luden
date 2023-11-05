import { Navbar } from '@/components/navbar'
import ProtectedRoute from '@/components/protected-route'
import { ScrollArea } from '@/components/ui/scroll-area'
import { cn } from '@/lib/utils'
import { MenuIcon } from 'lucide-react'
import { ElementRef, useRef, useState } from 'react'
import { Outlet } from 'react-router-dom'
import { useMediaQuery } from 'usehooks-ts'

const Navigation = () => {
  const isMobile = useMediaQuery('(max-width: 768px)')
  const navbarRef = useRef<ElementRef<'div'>>(null)
  const [isResetting, setIsResetting] = useState(false)
  const [isCollapsed, setIsCollapsed] = useState(isMobile)
  const sidebarRef = useRef<ElementRef<'aside'>>(null)

  const Page = () => {
    return (
      <ScrollArea>
        <div className="bg-background h-[90vh] mx-[2vw] my-[2vh]">
          <Outlet />
        </div>
      </ScrollArea>
    )
  }
  const resetWidth = () => {
    if (sidebarRef.current && navbarRef.current) {
      setIsCollapsed(false)
      setIsResetting(true)

      sidebarRef.current.style.width = isMobile ? '100%' : '240px'
      navbarRef.current.style.setProperty(
        'width',
        isMobile ? '0' : 'calc(100% - 240px)',
      )
      navbarRef.current.style.setProperty('left', isMobile ? '100%' : '240px')
      setTimeout(() => setIsResetting(false), 300)
    }
  }
  return (
    <ProtectedRoute>
      <Navbar
        isMobile={isMobile}
        navbarRef={navbarRef}
        resetWidth={resetWidth}
        sidebarRef={sidebarRef}
        setIsCollapsed={setIsCollapsed}
        setIsResetting={setIsResetting}
        isResetting={isResetting}
      />
      <div
        ref={navbarRef}
        className={cn(
          'absolute top-0 z-[99999] left-60 w-[calc(100%-240px)]',
          isResetting && 'transition-all ease-in-out duration-300',
          isMobile && 'left-0 w-full',
        )}
      >
        <div className="bg-primary-foreground h-[6vh] flex flex-row">
          {isCollapsed && (
            <MenuIcon
              onClick={resetWidth}
              role="button"
              className="text-muted-foreground h-full w-7 mx-2 transition-all ease-in-out duration-100"
            />
          )}
        </div>
        {isMobile ? isCollapsed && <Page /> : <Page />}
      </div>
    </ProtectedRoute>
  )
}

export default Navigation
