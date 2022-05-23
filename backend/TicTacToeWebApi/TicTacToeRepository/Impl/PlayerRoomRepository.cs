using System.Collections.Generic;
using System.Linq;
using TicTacToeDomain;

namespace TicTacToeRepository.Impl
{
    public class PlayerRoomRepository : GenericRepository<PlayerRoom>, IPlayerRoomRepository
    {
        private readonly TicTacToeDbContext _dbContext;
        public PlayerRoomRepository(TicTacToeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public PlayerRoom GetByName(string name)
        {
            return _dbContext.Set<PlayerRoom>().FirstOrDefault(r => r.Name == name);
        }
    }
}