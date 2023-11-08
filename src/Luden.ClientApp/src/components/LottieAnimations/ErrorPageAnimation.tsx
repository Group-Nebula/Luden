import Lottie from 'react-lottie'
import errorPageAnimation from '../../assets/Lottie.json/error-page-animation2.json'

export default function ErrorPageAnimation() {
  const defaultOptions = {
    animationData: errorPageAnimation,
  }
  return <Lottie options={defaultOptions} width={400} height={400} />
}
