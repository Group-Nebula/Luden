import { zodResolver } from '@hookform/resolvers/zod'
import { useFieldArray, useForm } from 'react-hook-form'
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
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from './ui/select'
import { Textarea } from './ui/textarea'
import { cn } from '@/lib/utils'
import { X } from 'lucide-react'
import axios from 'axios'
import { Endpoints } from '@/api/Endpoints'
import { toast } from '@/components/ui/use-toast'
import { useNavigate } from 'react-router-dom'

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
  config: z.object({
    skillDice: z.string(),
  }),
  skills: z.array(z.string()),
})

const RpgSystemsForm = () => {
  const navigate = useNavigate()

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      name: '',
      description: '',
      imageUrl: '',
      config: {
        skillDice: 'd20',
      },
      skills: ['Acrobatics'],
    },
    mode: 'onChange',
  })

  const { fields, append, remove } = useFieldArray({
    name: 'skills',
    control: form.control,
  })

  function onSubmit(values: z.infer<typeof formSchema>) {
    axios
      .post(Endpoints.CreateRpgSystem, values)
      .then(() => {
        toast({
          title: 'Sucess',
          description: 'rpg system created!',
          variant: 'default',
        })
        navigate('/app/rpg-systems')
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
                <FormLabel>System name</FormLabel>
                <FormControl>
                  <Input placeholder="D&D" {...field} />
                </FormControl>
                <FormDescription>
                  This is your public system name.
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
                  <Input
                    placeholder="https://example.com/image.png"
                    {...field}
                  />
                </FormControl>
                <FormDescription>
                  This is your public system image.
                  <br />
                  {field.value !== null && field.value !== '' && (
                    <img
                      src={field.value}
                      alt="system image"
                      className="aspect-[315/250] h-[210px] w-[200px] border border-input"
                    />
                  )}
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <FormField
            control={form.control}
            name="config.skillDice"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Dice</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger>
                      <SelectValue placeholder="Select a dice for the base of system" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="D20">D20</SelectItem>
                    <SelectItem value="D12">D12</SelectItem>
                    <SelectItem value="D100">D100</SelectItem>
                  </SelectContent>
                </Select>
                <FormDescription>
                  This wil be the base dice for rolls in attributes.
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />

          <div>
            {fields.map((field: Record<'id', string>, index: number) => (
              <FormField
                control={form.control}
                key={field.id}
                name={`skills.${index}`}
                render={({ field }) => (
                  <FormItem>
                    <FormLabel className={cn(index !== 0 && 'sr-only')}>
                      Skill
                    </FormLabel>
                    <FormDescription className={cn(index !== 0 && 'sr-only')}>
                      Add skills to your system, used to characters and
                      monsters.
                    </FormDescription>
                    <FormControl>
                      <div className="relative w-full">
                        <Button
                          variant="link"
                          className="absolute inset-y-0 right-0 flex items-center pr-3"
                          onClick={() => remove(index)}
                        >
                          <X className="text-destructive" />
                        </Button>
                        <Input placeholder="Acrobatics" {...field} />
                      </div>
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
            ))}
            <Button
              type="button"
              variant="outline"
              size="sm"
              className="mt-2"
              onClick={() => append('')}
            >
              Add Attribute
            </Button>
          </div>
          <Button type="submit">Submit</Button>
        </form>
      </Form>
    </>
  )
}

export default RpgSystemsForm
