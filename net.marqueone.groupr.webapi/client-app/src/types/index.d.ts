export interface Group {
  id: number
  name: string
  description?: string
}

export interface IconProps extends Props {
  icon: string,
  text?: string
  circle?: boolean
  outline?: boolean,
  size?: ButtonSize,
  width?: ButtonWidth,
  block?: boolean,
  color?: Color,
  onClick?: (event: React.MouseEvent<HTMLButtonElement | HTMLAnchorElement>) => void
}