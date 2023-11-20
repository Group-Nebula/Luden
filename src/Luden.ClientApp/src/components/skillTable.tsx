import { Input } from './ui/input'
import { Button } from './ui/button'
import { ScrollArea, ScrollBar } from './ui/scroll-area'

export type Skill = {
  id: string
  name: string
  value: string
}

export const nameCol = [
  {
    key: 'name',
    header: 'Skill',
    IsEditable: false,
  },
]

export const nameValueCol = [
  {
    key: 'name',
    header: 'Skill',
    IsEditable: false,
    IsActions: false,
  },
  {
    key: 'value',
    header: 'Value',
    IsEditable: true,
    IsActions: false,
  },
]

export interface SkillTableProps extends React.HTMLAttributes<HTMLDivElement> {
  columns: {
    key: string
    header: string
    IsEditable: boolean
    IsActions: boolean
  }[]
  data: Skill[]
  setData: React.Dispatch<React.SetStateAction<Skill[]>>
}

const SkillTable = (props: SkillTableProps) => {
  return (
    <ScrollArea className="w-full flex flex-col m-1">
      <div className="overflow-x-auto">
        <div className="min-w-full inline-block align-middle rounded-sm border border-input">
          <div className="overflow-hidden">
            <table className="min-w-full divide-y">
              <thead>
                <tr>
                  {props.columns.map((column) => (
                    <th
                      scope="col"
                      className="px-6 py-3 text-center text-xs font-medium text-foreground uppercase tracking-wider"
                      key={column.key}
                    >
                      {column.header}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody className="p-1.5">
                {props.data.length < 1 && (
                  <tr className="py-10 border-t border-input h-10">
                    <td className="text-end text-sm whitespace-nowrap">
                      No skills added yet...
                    </td>
                  </tr>
                )}
                {props.data.map((row) => (
                  <tr
                    key={row.id}
                    className="px-6 whitespace-nowrap text-sm border-t border-input"
                  >
                    {props.columns.map((column) => {
                      return (
                        <td key={column.key} className="px-6 whitespace-nowrap">
                          {column.IsEditable && (
                            <Input
                              {...props}
                              className="border-none text-center w-full focus-visible:outline-none focus-visible:ring-0 focus-visible:ring-offset-0"
                              value={row[column.key as keyof Skill]}
                              onChange={(e) => {
                                props.setData(
                                  props.data.map((item) => {
                                    if (item.id === row.id) {
                                      return {
                                        ...item,
                                        [column.key]: e.target.value,
                                      }
                                    }
                                    return item
                                  }),
                                )
                              }}
                            />
                          )}
                          {column.IsActions && (
                            <Button
                              variant="link"
                              className="w-full text-center mx-3"
                              onClick={() =>
                                props.setData(
                                  props.data.filter(
                                    (item) => item.id !== row.id,
                                  ),
                                )
                              }
                            >
                              Delete
                            </Button>
                          )}
                          {!column.IsEditable && !column.IsActions && (
                            <div className="w-full text-center mx-3">
                              {row[column.key as keyof Skill]}
                            </div>
                          )}
                        </td>
                      )
                    })}
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      </div>
      <ScrollBar orientation="horizontal" />
    </ScrollArea>
  )
}
export { SkillTable }
