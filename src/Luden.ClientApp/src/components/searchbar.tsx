import { Button } from './ui/button'
import { Input } from './ui/input'
import { Search } from 'lucide-react'

export interface SearchBarProps extends React.HTMLAttributes<HTMLDivElement> {
  getdata: () => void
  setdata: React.Dispatch<React.SetStateAction<string>>
  children?: React.ReactNode
}

const SearchBar = (props: SearchBarProps) => {
  return (
    <div {...props} className="relative">
      <Button
        variant="link"
        className="absolute inset-y-0 right-0 flex items-center pr-3"
        type="button"
        onClick={props.getdata}
      >
        <Search className="text-input" />
      </Button>
      <Input
        placeholder="Search for a system"
        onChange={(e) => {
          props.setdata(e.target.value)
        }}
      />
      {props.children}
    </div>
  )
}

export default SearchBar
