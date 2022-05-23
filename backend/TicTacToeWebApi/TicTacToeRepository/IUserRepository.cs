using System.Dynamic;
using TicTacToeDomain;

namespace TicTacToeRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public User GetUsingCredentials(string username, string password);
    }
}