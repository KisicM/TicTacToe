import Square from "../Square/Square";
import styles from "./Board.module.css";

type BoardProps = {
  squares: Array<string>,
  onClick: (squareIndex:number) => void,
  canPlay: boolean
} 

const Board = ({squares, onClick, canPlay}: BoardProps): JSX.Element => {
  return (
    <>
      <div className={styles.board}>
        <Square value = {squares[0]} onClick = {() => onClick(0)} canPlay={canPlay}/>
        <Square value = {squares[1]} onClick = {() => onClick(1)} canPlay={canPlay} />
        <Square value = {squares[2]} onClick = {() => onClick(2)} canPlay={canPlay}/>
      </div>
      <div className={styles.board}>
        <Square value = {squares[3]} onClick = {() => onClick(3)} canPlay={canPlay}/>
        <Square value = {squares[4]} onClick = {() => onClick(4)} canPlay={canPlay}/>
        <Square value = {squares[5]} onClick = {() => onClick(5)} canPlay={canPlay}/>
      </div>
      <div className={styles.board}>
        <Square value = {squares[6]} onClick = {() => onClick(6)} canPlay={canPlay}/>
        <Square value = {squares[7]} onClick = {() => onClick(7)} canPlay={canPlay}/>
        <Square value = {squares[8]} onClick = {() => onClick(8)} canPlay={canPlay}/>
      </div>
    </>
  );
}
export default Board