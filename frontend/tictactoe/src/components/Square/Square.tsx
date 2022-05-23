import styles from './Square.module.css'

type SquareProps = {
  value: string,
  onClick: () => void,
  canPlay: boolean,
}

const Square = ({value, onClick, canPlay} : SquareProps): JSX.Element => {
  return (
    (canPlay ? 
      <button className={styles.square} onClick={onClick}>
        {value}
      </button>
      : <button disabled className={styles.square} onClick={onClick}>
      {value}
    </button>)
    )
}
export default Square