import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import * as z from 'zod'

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
import { SkillTable, nameValueCol, Skill } from './skillTable'
import { cn } from '@/lib/utils'
import {
  Popover,
  PopoverTrigger,
  PopoverContent,
} from '@radix-ui/react-popover'
import { format } from 'date-fns'
import { CalendarIcon, Search } from 'lucide-react'
import { Calendar } from './ui/calendar'
import { useEffect, useState } from 'react'
import { Endpoints } from '@/api/Endpoints'
import axios from 'axios'
import { toast } from './ui/use-toast'
import { Separator } from './ui/separator'
import { ScrollArea } from './ui/scroll-area'
import { Textarea } from './ui/textarea'
import { parseJwt } from '@/utils/token'
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from './ui/select'
import { useNavigate } from 'react-router-dom'

const formSchema = z.object({
  name: z.string().min(2, {
    message: 'Username must be at least 2 characters.',
  }),
  birthDate: z.date(),
  description: z
    .string()
    .min(2, {
      message: 'description must be at least 2 characters.',
    })
    .max(100, {
      message: 'description must be at most 100 characters.',
    }),
  imageUrl: z.string().url({ message: 'Please enter a valid URL.' }),
  status: z.string(),
  skills: z.array(
    z.object({
      id: z.string(),
      name: z.string(),
      value: z.string(),
    }),
  ),
  system: z.string().uuid({ message: 'Please enter a valid system.' }),
})

interface Systems {
  id: string
  name: string
}

const CharactersForm = () => {
  const navigate = useNavigate()
  const [skills, setSkills] = useState<Skill[]>([] as Skill[])
  const [systemName, setSystemName] = useState('')
  const [systems, setSystems] = useState<Systems[]>([] as Systems[])
  const [system, setSystem] = useState<Systems | undefined>(undefined)

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: '',
      birthDate: new Date(),
      description: '',
      imageUrl: '',
      status: '0',
      skills: [],
      system: 'Select a system...',
    },
    mode: 'onChange',
  })

  function onSubmit(values: z.infer<typeof formSchema>) {
    if (system !== undefined) values.system = system.id
    axios
      .post(Endpoints.CreateCharacter, {
        userId: (parseJwt() as { unique_name: string }).unique_name,
        name: values.name,
        birthDate: values.birthDate,
        description: values.description,
        imageUrl: values.imageUrl,
        status: Number(values.status),
        skills: skills.flatMap((skill) => {
          return { key: skill.id, value: Number(skill.value) }
        }),
      })
      .then((response) => {
        navigate('/app/characters')
        toast({
          title: 'Character created!',
          description: 'Your character was successfully created.',
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

  useEffect(() => {
    if (system !== undefined) {
      GetSkills()
    }
  }, [system])

  useEffect(() => {
    GetSystems()
  }, [])

  const GetSkills = () => {
    axios
      .get(Endpoints.ListAllSkills + `?rpgSystemId=${system?.id}`)
      .then((response) => {
        setSkills(response.data)
      })
      .catch((error) => {
        toast({
          title: error.response.data.title,
          description: error.response.data.detail,
          variant: 'destructive',
        })
      })
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="space-y-4 w-[70%] max-md:w-[90%] pe-10"
      >
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Name</FormLabel>
              <FormControl>
                <Input placeholder="e. g. Tristan Agostini" {...field} />
              </FormControl>
              <FormDescription>
                This is your public character display name.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="birthDate"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Date of birth</FormLabel>
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
                Your date of birth is used to calculate your character age.
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
                This is your public system description.
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
                <Input placeholder="https://example.com/image.png" {...field} />
              </FormControl>
              <FormDescription>
                This is your public character image.
                <br />
                {field.value !== null && field.value !== '' && (
                  <img
                    src={field.value}
                    alt="character image"
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
          name="status"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Status</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
                    <SelectValue placeholder="Select a status to your character" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  <SelectItem value="0">Normal</SelectItem>
                  <SelectItem value="1">Dead</SelectItem>
                  <SelectItem value="2">Unconscious</SelectItem>
                  <SelectItem value="3">Insane</SelectItem>
                </SelectContent>
              </Select>
              <FormDescription>
                You can switch your character status later.
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
                    <PopoverContent className="z-[9999] bg-background rounded-sm border border-input w-[60vw] max-md:w-[80vw]">
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
                This is your public display name.
              </FormDescription>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="skills"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Skills</FormLabel>
              <FormControl>
                <SkillTable
                  {...field}
                  columns={nameValueCol}
                  data={skills}
                  setData={setSkills}
                />
              </FormControl>
            </FormItem>
          )}
        />

        <Button type="submit">Submit</Button>
      </form>
    </Form>
  )
}

export default CharactersForm
