using System.Collections.Generic;
using System.Linq;
using TicTacToeDomain;

namespace TicTacToeRepository.Impl
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly TicTacToeDbContext _dbContext;

        public GameRepository(TicTacToeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Game UpdateWinner(Game game)
        {
            Game oldGame = _dbContext.Set<Game>().FirstOrDefault(g => g.Id == game.Id);
            if (oldGame == null) return null;
            oldGame.Outcome = game.Outcome;
            _dbContext.Set<Game>().Update(oldGame);
            Save();
            return oldGame;
        }
    }
}