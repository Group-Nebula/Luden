import { zodResolver } from '@hookform/resolvers/zod'
import { useFieldArray, useForm } from 'react-hook-form'
import * as z from 'zod'
import { format } from 'date-fns'
import { Button } from '@/components/ui/button'
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form'
import { Input } from '@/components/ui/input'

import { Textarea } from './ui/textarea'
import { cn } from '@/lib/utils'
import { CalendarIcon, Search, X } from 'lucide-react'
import axios from 'axios'
import { Endpoints } from '@/api/Endpoints'
import { toast } from '@/components/ui/use-toast'
import { useNavigate } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { parseJwt } from '@/utils/token'
import { Popover, PopoverContent, PopoverTrigger } from './ui/popover'
import { Calendar } from './ui/calendar'
import { ScrollArea } from './ui/scroll-area'
import { Separator } from './ui/separator'

const formSchema = z.object({
  name: z.string().min(2, {
    message: 'name must be at least 2 characters.',
  }),
  description: z
    .string()
    .min(2, {
      message: 'description must be at least 2 characters.',
    })
    .max(100, {
      message: 'description must be at most 100 characters.',
    }),
  imageUrl: z.string().url({ message: 'Please enter a valid URL.' }),
  rpgDate: z.date(),
  system: z.string().uuid({ message: 'Please enter a valid system.' }),
})

interface IdName {
  id: string
  name: string
}

const RpgsForm = () => {
  const [systemName, setSystemName] = useState('')
  const [systems, setSystems] = useState<IdName[]>([] as IdName[])
  const [system, setSystem] = useState<IdName | undefined>(undefined)

  const [userName, setUserName] = useState('')
  const [users, setUsers] = useState<IdName[]>([] as IdName[])
  const [searchUsers, setSearchUsers] = useState<IdName[]>([] as IdName[])
  const [user] = useState<IdName>({} as IdName)

  const navigate = useNavigate()

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: '',
      description: '',
      imageUrl: '',
      rpgDate: new Date(),
      system: '',
    },
    mode: 'onChange',
  })

  function onSubmit(values: z.infer<typeof formSchema>) {
    if (system !== undefined) values.system = system.id
    axios
      .post(Endpoints.CreateRpg, {
        masterId: (parseJwt() as { unique_name: string }).unique_name,
        name: values.name,
        description: values.description,
        imageUrl: values.imageUrl,
        rpgDate: values.rpgDate,
        rpgSystemId: values.system,
        rpgPlayers: users.map((u) => u.id),
      })
      .then(() => {
        navigate('/app/rpg')
        toast({
          title: 'Sucess',
          description: 'Rpg system created!',
          variant: 'default',
        })
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  }

  const GetSystems = () => {
    axios
      .get(Endpoints.ListAllRpgSystem + `?rpgSystemName=${systemName}`)
      .then((response) => {
        setSystems(response.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  }

  const GetUsers = () => {
    axios
      .get(Endpoints.GetAllUsers + `?username=${userName}`)
      .then((response) => {
        setSearchUsers(response.data?.data ?? [])
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
    if (system === undefined) {
      GetSystems()
    }
  }, [])

  useEffect(() => {
    if (searchUsers?.length === 0) {
      GetUsers()
    }
  }, [])

  return (
    <>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="space-y-4 w-[70%] max-md:w-full pe-10"
        >
          <FormField
            control={form.control}
            name="name"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Rpg name</FormLabel>
                <FormControl>
                  <Input placeholder="Montybell" {...field} />
                </FormControl>
                <FormDescription>This is your public rpg name.</FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="rpgDate"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Date of RPG</FormLabel>
                <Popover>
                  <PopoverTrigger asChild>
                    <FormControl>
                      <Button
                        variant={'outline'}
                        className={cn(
                          'w-[240px] pl-3 text-left font-normal',
                          !field.value && 'text-muted-foreground',
                        )}
                      >
                        {field.value ? (
                          format(field.value, 'PPP')
                        ) : (
                          <span>Pick a date</span>
                        )}
                        <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                      </Button>
                    </FormControl>
                  </PopoverTrigger>
                  <PopoverContent
                    className="w-auto p-0 bg-background z-[99999]"
                    align="start"
                  >
                    <Calendar
                      mode="single"
                      selected={field.value}
                      onSelect={field.onChange}
                      initialFocus
                    />
                  </PopoverContent>
                </Popover>
                <FormDescription>
                  The actual data that the RPG will happen.
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="description"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Description</FormLabel>
                <FormControl>
                  <Textarea
                    placeholder="type the description here..."
                    {...field}
                  />
                </FormControl>
                <FormDescription>
                  This is your public rpg description.
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="imageUrl"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Image Url</FormLabel>
                <FormControl>
                  <Input
                    placeholder="https://example.com/image.png"
                    {...field}
                  />
                </FormControl>
                <FormDescription>
                  This is your public rpg image.
                  <br />
                  {field.value !== null && field.value !== '' && (
                    <img
                      src={field.value}
                      alt="system image"
                      className="aspect-square h-[200px] w-[200px] border border-input"
                    />
                  )}
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="system"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Rpg System</FormLabel>
                <FormControl className="w-full">
                  <Popover>
                    <PopoverTrigger asChild>
                      <div className="relative w-full">
                        <Button
                          variant="link"
                          className="absolute inset-y-0 right-0 flex items-center pr-3"
                          type="button"
                          onClick={GetSystems}
                        >
                          <Search className="opacity-50" />
                        </Button>
                        <Input
                          className="placeholder:text-foreground"
                          placeholder={system?.name ?? 'Select a system...'}
                          onChange={(e) => {
                            setSystemName(e.target.value)
                          }}
                        />
                      </div>
                    </PopoverTrigger>
                    {systems.length > 0 && (
                      <PopoverContent className="z-[99999] p-0 bg-background rounded-sm border border-input w-[60vw] max-md:w-[80vw]">
                        <ScrollArea>
                          <div className="grid w-full">
                            {systems.map((system) => (
                              <div key={system.id} className="w-full">
                                <Button
                                  variant="link"
                                  type="button"
                                  value={system.name}
                                  className="font-medium leading-none w-max"
                                  onClick={() => {
                                    field.onChange(system.id)
                                    setSystem(system)
                                  }}
                                >
                                  {system.name}
                                </Button>
                                <div className="px-3 text-center">
                                  <Separator />
                                </div>
                              </div>
                            ))}
                          </div>
                        </ScrollArea>
                      </PopoverContent>
                    )}
                  </Popover>
                </FormControl>
                <FormDescription>
                  This is the system that your rpg will use.
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <div>
            <FormLabel>Players</FormLabel>
            <FormDescription>Add players to your rpg.</FormDescription>
            <Popover>
              <PopoverTrigger asChild>
                <div className="relative w-full">
                  <Button
                    variant="link"
                    className="absolute inset-y-0 right-0 flex items-center pr-3"
                    type="button"
                    onClick={GetUsers}
                  >
                    <Search className="opacity-50" />
                  </Button>
                  <Input
                    className="placeholder:text-foreground"
                    placeholder={user?.name ?? 'Add a user...'}
                    onChange={(e) => {
                      setUserName(e.target.value)
                    }}
                  />
                </div>
              </PopoverTrigger>
              {searchUsers !== undefined && searchUsers.length > 0 && (
                <PopoverContent className="z-[99999] p-0 bg-background rounded-sm border border-input w-[60vw] max-md:w-[80vw]">
                  <ScrollArea>
                    <div className="grid w-full">
                      {searchUsers.map((user) => (
                        <div key={user.id} className="w-full">
                          <Button
                            variant="link"
                            type="button"
                            value={user.name}
                            className="font-medium leading-none w-max"
                            onClick={() => {
                              if (!users.includes(user)) {
                                setUsers([...users, user])
                              } else {
                                toast({
                                  title: 'User already added',
                                  variant: 'destructive',
                                })
                              }
                            }}
                          >
                            {user.name}
                          </Button>
                          <div className="px-3 text-center">
                            <Separator />
                          </div>
                        </div>
                      ))}
                    </div>
                  </ScrollArea>
                </PopoverContent>
              )}
            </Popover>
            <div className="border border-sm border-input p-3">
              {users.map((item) => (
                <FormItem key={item.id}>
                  <FormControl>
                    <div className="relative w-full my-2">
                      <Button
                        variant="link"
                        type="button"
                        className="absolute inset-y-0 right-0 flex items-center pr-3"
                        onClick={() =>
                          setUsers(users.filter((u) => u !== item))
                        }
                      >
                        <X className="text-destructive" />
                      </Button>
                      <Input
                        value={item.name}
                        className="pointer-events-none"
                      />
                    </div>
                  </FormControl>
                  <FormMessage />
                </FormItem>
              ))}
            </div>
          </div>

          <Button type="submit">Submit</Button>
        </form>
      </Form>
    </>
  )
}

export default RpgsForm
