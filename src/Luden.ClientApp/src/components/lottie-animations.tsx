import NoData from '@/assets/animations/no-data.json'
import ErroPage from '@/assets/animations/error-page.json'
import Lottie from 'lottie-react'

const ErrorPageAnimation = (props: React.HTMLAttributes<HTMLDivElement>) => {
  return (
    <Lottie
      {...props}
      autoplay={true}
      animationData={ErroPage}
      loop={false}
      onComplete={() => {
        stop()
      }}
    />
  )
}

const NoDataAnimation = (props: React.HTMLAttributes<HTMLDivElement>) => {
  return (
    <Lottie
      {...props}
      autoplay={true}
      animationData={NoData}
      loop={false}
      onComplete={() => {
        stop()
      }}
    />
  )
}

export { ErrorPageAnimation, NoDataAnimation }
