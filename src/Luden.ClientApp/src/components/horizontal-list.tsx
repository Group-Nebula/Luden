const HorizontalList = () => {
  const items = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
  return (
    <div className="flex flex-row">
      {items.map((index) => (
        <div key={index} className="m-1">
          <div className="w-[15rem] h-[15rem] bg-primary-foreground"></div>
        </div>
      ))}
    </div>
  )
}

export default HorizontalList
