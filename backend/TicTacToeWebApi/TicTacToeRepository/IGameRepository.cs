using TicTacToeDomain;

namespace TicTacToeRepository
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        public Game UpdateWinner(Game game);
    }
}