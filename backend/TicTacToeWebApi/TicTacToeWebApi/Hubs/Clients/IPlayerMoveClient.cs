using System.Threading.Tasks;
using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeWebApi.Hubs.Clients
{
    public interface IPlayerMoveClient
    {
        Task RecievePlayerMove(GameDTO gameDto);
        Task ReceiveGame(Game game);
    }
}