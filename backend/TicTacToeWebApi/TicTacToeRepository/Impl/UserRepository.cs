using System.Data.Entity;
using System.Linq;
using TicTacToeDomain;

namespace TicTacToeRepository.Impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TicTacToeDbContext _dbContext;

        public UserRepository(TicTacToeDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUsingCredentials(string username, string password)
        { 
            return _dbContext.Set<User>().FirstOrDefault(u => u.Username == username && u.Password == password);
        }

    }
}