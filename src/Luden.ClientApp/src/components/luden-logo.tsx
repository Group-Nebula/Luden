import { HTMLAttributes, useState } from 'react'

const isDarkMode = localStorage.getItem('vite-ui-theme') === 'dark'

type LudenImagotypeProps = React.SVGProps<SVGSVGElement>

const LudenImagotype = (props: LudenImagotypeProps) => {
  const LudenDarkImagotype = (props: LudenImagotypeProps) => {
    return (
      <svg
        width="62"
        height="50"
        viewBox="0 0 62 71"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M9.5 25H54.5M9.5 25L32.5 60.5M9.5 25L32.5 1M9.5 25L2.5 15.5M9.5 25L1 52M54.5 25L32.5 60.5M54.5 25L32.5 1M54.5 25L61.5 15.5M54.5 25L61.5 52M32.5 60.5L1 52M32.5 60.5L61.5 52M32.5 60.5V70M32.5 1L61.5 15.5M32.5 1L2.5 15.5M61.5 15.5V52M2.5 15.5L1 52M1 52L32.5 70M61.5 52L32.5 70"
          stroke="white"
        />
      </svg>
    )
  }

  const LudenLightImagotype = (props: LudenImagotypeProps) => {
    return (
      <svg
        width="62"
        height="50"
        viewBox="0 0 62 71"
        fill="none"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          d="M9.5 25H54.5M9.5 25L32.5 60.5M9.5 25L32.5 1M9.5 25L2.5 15.5M9.5 25L1 52M54.5 25L32.5 60.5M54.5 25L32.5 1M54.5 25L61.5 15.5M54.5 25L61.5 52M32.5 60.5L1 52M32.5 60.5L61.5 52M32.5 60.5V70M32.5 1L61.5 15.5M32.5 1L2.5 15.5M61.5 15.5V52M2.5 15.5L1 52M1 52L32.5 70M61.5 52L32.5 70"
          stroke="black"
        />
      </svg>
    )
  }

  return isDarkMode ? (
    <LudenDarkImagotype {...props} />
  ) : (
    <LudenLightImagotype {...props} />
  )
}

export default LudenImagotype
