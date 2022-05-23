using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeService
{
    public interface ILoginService
    {
        public User GetUsingCredentials(LoginDTO loginDTO);
    }
}