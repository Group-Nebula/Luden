import { ChevronsLeft } from 'lucide-react'
import { RefObject, useEffect, useRef } from 'react'
import { cn } from '@/lib/utils'
import { Button } from '@/components/ui/button'

interface NavbarProps {
  isMobile: boolean
  resetWidth: () => void
  sidebarRef: RefObject<HTMLElement>
  navbarRef: RefObject<HTMLDivElement>
  setIsCollapsed: (arg: boolean) => void
  setIsResetting: (arg: boolean) => void
  isResetting: boolean
}

export const Navbar = (props: NavbarProps) => {
  const isResizingRef = useRef(false)

  useEffect(() => {
    if (props.isMobile) {
      collapse()
    } else {
      props.resetWidth()
    }
  }, [props.isMobile])

  const handleMouseDown = (
    event: React.MouseEvent<HTMLDivElement, MouseEvent>,
  ) => {
    event.preventDefault()
    event.stopPropagation()

    isResizingRef.current = true
    document.addEventListener('mousemove', handleMouseMove)
    document.addEventListener('mouseup', handleMouseUp)
  }

  const handleMouseMove = (event: MouseEvent) => {
    if (!isResizingRef.current) return
    let newWidth = event.clientX

    if (newWidth < 240) newWidth = 240
    if (newWidth > 480) newWidth = 480

    if (props.sidebarRef.current && props.navbarRef.current) {
      props.sidebarRef.current.style.width = `${newWidth}px`
      props.navbarRef.current.style.setProperty('left', `${newWidth}px`)
      props.navbarRef.current.style.setProperty(
        'width',
        `calc(100% - ${newWidth}px)`,
      )
    }
  }

  const handleMouseUp = () => {
    isResizingRef.current = false
    document.removeEventListener('mousemove', handleMouseMove)
    document.removeEventListener('mouseup', handleMouseUp)
  }

  const collapse = () => {
    if (props.sidebarRef.current && props.navbarRef.current) {
      props.setIsCollapsed(true)
      props.setIsResetting(true)

      props.sidebarRef.current.style.width = '0'
      props.navbarRef.current.style.setProperty('width', '100%')
      props.navbarRef.current.style.setProperty('left', '0')
      setTimeout(() => props.setIsResetting(false), 300)
    }
  }

  return (
    <aside
      ref={props.sidebarRef}
      className={cn(
        'group/sidebar h-[100vh] bg-muted overflow-y-auto relative flex w-60 flex-col z-[99999]',
        props.isResetting && 'transition-all ease-in-out duration-300',
        props.isMobile && 'w-0',
      )}
    >
      <Button
        onClick={collapse}
        size="icon"
        variant="link"
        className={cn(
          'h-6 w-6 text-muted-foreground rounded-sm hover:bg-background absolute top-3 right-2 opacity-0 group-hover/sidebar:opacity-100 transition',
          props.isMobile && 'opacity-100',
        )}
      >
        <ChevronsLeft className="h-6 w-6" />
      </Button>
      <div
        onMouseDown={handleMouseDown}
        onClick={props.resetWidth}
        className="opacity-0 group-hover/sidebar:opacity-100 transition cursor-ew-resize absolute h-full w-1 bg-primary/10 right-0 top-0"
      />
    </aside>
  )
}
