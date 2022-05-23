using TicTacToeDomain;

namespace TicTacToeRepository
{
    public interface IPlayerRoomRepository : IGenericRepository<PlayerRoom>
    {
        public PlayerRoom GetByName(string name);
    }
}