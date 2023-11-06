import { useRef } from 'react'
import { ScrollArea, ScrollBar } from './ui/scroll-area'

interface HorizontalListProps {
  items: { id: number; name: string; description: string; image: string }[]
}

const HorizontalList = (props: HorizontalListProps) => {
  return (
    <ScrollArea className="w-full">
      <div className="flex flex-row w-max m-2">
        {props.items.map((item) => (
          <div key={item.id} className="m-1 w-[12rem]">
            <img
              src={item.image}
              alt={item.name}
              className="cover h-[12rem] rounded-md"
            />
            <div className="space-y-1 text-sm">
              <h3 className="font-medium leading-none">{item.name}</h3>
              <p className="text-xs text-muted-foreground">
                {item.description}
              </p>
            </div>
          </div>
        ))}
      </div>
      <ScrollBar orientation="horizontal" className="mt-2" />
    </ScrollArea>
  )
}

export default HorizontalList
