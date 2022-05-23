import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import React, { useCallback, useEffect, useState } from "react";
import { Link } from "react-router-dom";
import calculateWinner from "../../utils/calculateWinner";
import checkStatus from "../../utils/checkStatus";
import Board from "../Board/Board";
import Button from "../shared/Button/Button";

export type GameState = {
  history: { squares: Array<string> }[],
  stepNumber: number,
  xIsNext: boolean,
}

type MatchState = {
    gameId: number,
    playerId: number,
    outcome: number
}

const Game = (): JSX.Element => {
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const [state, setState] = useState<GameState>(
    {
      history: [
        {
          squares: Array(9).fill(null)
        }
      ],
      stepNumber: 0,
      xIsNext: true
    }
  );
  const [isSender, setIsSender] = useState<boolean>(true);
  const [currentIndex, setCurrentIndex] = useState<number>(-1);
  const [match, setMatch] = useState<MatchState>({
    gameId: 0,
    playerId: -1,
    outcome: -1,
  });

  const createNewGame = async () => {
    const newGame = {
      Id: match.gameId,
      PlayerId: match.playerId,
      Outcome: match.outcome,
      SquareIndex: -1,
      RoomId: localStorage.getItem("roomId"),
    }
    if(connection) {
      try {
        await connection.send('SendGame', newGame);
        console.log('Game sent');
      }
      catch(e) {
        console.log(e);
      }
    }
    else {
      alert('Connection not established, game not sent');
    }
  } 

  const newGameCallback = useCallback(createNewGame, [connection, match])

  useEffect(() => {
    const newConnection = new HubConnectionBuilder()
      .withUrl('https://localhost:5001/hubs/playerMove')
      .withAutomaticReconnect()
      .build();
    setConnection(newConnection);
  }, []);

  const sendMove = async (squareIndex: number) => {
    const gameDto = {
      Id: match.gameId,
      PlayerId: match.playerId,
      Outcome: match.outcome,
      SquareIndex: squareIndex,
      RoomId: localStorage.getItem("roomId"),
    }
    if(connection) {
      try {
        await connection.send('SendPlayerMove', gameDto);
      }
      catch(e) {
        console.log(e);
      }
    }
    else {
      alert('Connection not established');
    }
  }

  const sendMoveCallback = useCallback(sendMove, [connection, match])

  const handleClick = (currentIndex: number) => {
    const history = state.history.slice(0, state.stepNumber + 1);
    const current = history[history.length - 1];
    const squares = current.squares.slice();
    if (calculateWinner(squares) || squares[currentIndex]) {
      return;
    }
    squares[currentIndex] = state.xIsNext ? "X" : "O";
    setState({
      history: history.concat([
        {
          squares: squares
        }
      ]),
      stepNumber: history.length,
      xIsNext: !state.xIsNext
    });
    if(isSender) sendMoveCallback(currentIndex);
    setIsSender(!isSender)
  }

  const clickCallback = useCallback(handleClick, [isSender, sendMoveCallback, state]);

  useEffect(() => {
    if(currentIndex !== -1) clickCallback(currentIndex);
  }, [currentIndex, clickCallback, match]);
  
  useEffect(() => {
    if(connection) {
      connection.start()
        .then(result => {
          console.log('Connected!');
          
          newGameCallback();

          connection.on('ReceiveGame', game => {
            setMatch({
                gameId: game.id,
                playerId: game.playerId,
                outcome: game.outcome === "X" ? 0 : game.outcome === "O" ? 1 : 2
              })
          })
          
          connection.on('RecievePlayerMove', gameDto => {
            setIsSender(!isSender);
            setCurrentIndex(gameDto.squareIndex);      
          });
        })
        .catch(e => console.log('Connection failed: ', e));
    }
  }, [connection, isSender, match, newGameCallback]);

  const displayStatus = (): string => {
    const status = checkStatus(state, match)
    if (!status.includes('Next')) {
      //setIsSender(false);
    }
    return status 
  }

  return (
    <div className="board">
      <div className="game-info">
        <p>{displayStatus()}</p>
      </div>
      <div>
        <Board
          squares={state.history[state.stepNumber].squares}
          onClick={(squareIndex: number) => handleClick(squareIndex)}
          canPlay={isSender}
        />
      </div>
      <Link to={"/home"} >
        <Button btnType='button' btnStyle='secondary' content='Back to home' onClick={function (): void {
                      throw new Error('Function not implemented.')
                  } } />
      </Link>
    </div>
  );
}
export default Game