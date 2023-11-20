import { cn } from '@/lib/utils'
import { ScrollArea, ScrollBar } from './ui/scroll-area'
import { IsCollapsed } from '@/pages/navigation'
interface ListItem {
  id: string
  name: string
  description: string
  imageUrl: string
}

interface ListProps {
  items: ListItem[]
}

interface ItemCardProps {
  item: ListItem
  key: string
  className?: string
}

const ItemCard = ({ item, key, className }: ItemCardProps) => {
  return (
    <div key={key} className={cn('m-1 p-2 border-lg', className)}>
      <img
        src={item.imageUrl}
        alt={item.name}
        className="items-stretch aspect-square w-full"
      />
      <p className="text-start p-0 m-0 text-sm">{item.name}</p>
      <p className="text-xs text-muted-foreground">
        {item.description.substring(0, 50)}
        {item.description.length > 50 && '...'}
      </p>
    </div>
  )
}

const HorizontalList = (props: ListProps) => {
  return (
    <ScrollArea className="w-full">
      <div className="flex flex-row w-max m-2">
        {props.items.map((item) => (
          <ItemCard item={item} key={item.id} className="h-[200px] w-[200px]" />
        ))}
      </div>
      <ScrollBar orientation="horizontal" className="m-2" />
    </ScrollArea>
  )
}

const GridList = (props: ListProps) => {
  return (
    <ScrollArea className="w-full">
      <div
        className={cn(
          'grid justify-items-center sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-6',
          !IsCollapsed &&
            'sm:grid-cols-2 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-5',
        )}
      >
        {props.items.map((item) => (
          <ItemCard
            item={item}
            key={item.id}
            className="sm:w-[calc(640px/2)] md:w-[calc(90vw/3)] lg:w-[calc(90vw/4)] xl:w-[calc(90vw/6)]"
          />
        ))}
      </div>
    </ScrollArea>
  )
}

export { HorizontalList, ItemCard, GridList }
