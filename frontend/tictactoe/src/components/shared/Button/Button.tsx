import React from 'react'
import styles from './Button.module.css'

type ButtonProps = {
    onSubmit?: ((e: any) => Promise<void>),
    onClick?: () => void,
    content: string
    btnType: "button" | "submit" | "reset"
    btnStyle: "primary" | "secondary" | "danger" | "warning" | "success" | "friend" | "ai" | "others"
}

//create a function and use switch case to return button style based on btnStyle prop
const getButtonStyle = (btnStyle: string): string => {
    switch(btnStyle) {
        case "primary":
            return styles.primary
        case "secondary":
            return styles.secondary
        case "danger":
            return styles.danger
        case "warning":
            return styles.warning
        case "success":
            return styles.success
        case "friend":
            return styles.friend
        case "ai":
            return styles.ai
        case "others":
            return styles.others
        default:
            return styles.primary
    }
}

const Button = ({btnType, content, onClick, btnStyle}: ButtonProps): JSX.Element => {
  return (
    <button type={btnType} className={getButtonStyle(btnStyle)} onClick={onClick}>
      {content}
    </button>
  )
}

export default Button