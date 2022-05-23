import axios from "axios";
import GameDTO from "../../models/gameDto";

const gameUrl = "https://localhost:5001/api/Game"

const updateWinner = (gameDto: GameDTO) => axios.put(gameUrl, gameDto);

const gameService = {
    updateWinner,
}

export default gameService;