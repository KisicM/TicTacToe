using System.Collections.Generic;
using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeService
{
    public interface IGameService
    {
        public Game CreateGame(Game game);
        public Game GetGame(int id);
        public IEnumerable<Game> GetAllGames();
        public Game UpdateWinner(GameDTO gameDto);
    }
}