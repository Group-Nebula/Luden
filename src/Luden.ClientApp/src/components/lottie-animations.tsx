import { Player, Controls } from '@lottiefiles/react-lottie-player'
import NoData from '@/assets/animations/no-data.json'

const NoDataAnimation = (props: React.HTMLAttributes<HTMLDivElement>) => {
  return (
    <div {...props}>
      <Player autoplay={true} src={NoData} loop={false} keepLastFrame={true}>
        <Controls visible={false} />
      </Player>
    </div>
  )
}

export { NoDataAnimation }
