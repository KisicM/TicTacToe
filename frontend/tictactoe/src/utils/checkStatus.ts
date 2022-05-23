import { GameState } from '../components/Game/Game';
import calculateWinner from './calculateWinner';
import gameService from '../services/gameService/gameService';
import GameDTO from '../models/gameDto';

type MatchState = {
    gameId: number,
    playerId: number,
    outcome: number
}

const updateWinner = async (gameDto: GameDTO) => {
  const response = await gameService.updateWinner(gameDto);
  if(response.status === 200) console.log("Winner updated");
  else alert("Error updating winner");
}

const checkStatus = (state : GameState, game: MatchState): string => {
    let status: string;
    const winner = calculateWinner(state.history[state.stepNumber].squares);
    if (winner) {
      status = "Winner: " + winner;
      const updatedGame = {
        Id: game.gameId,
        PlayerId: game.playerId,
        Outcome: winner === "O" ? 1 : 0,
        SquareIndex: state.stepNumber
      };
      updateWinner(updatedGame)
    } 
    else if (state.stepNumber === 9) {
      status = "Draw";
      const updatedGame = {
        Id: game.gameId,
        PlayerId: game.playerId,
        Outcome: 2,
        SquareIndex: state.stepNumber
      };
      updateWinner(updatedGame)
    } 
    else {
      status = "Next player: " + (state.xIsNext ? "X" : "O");
    }
  return status
  
}

export default checkStatus