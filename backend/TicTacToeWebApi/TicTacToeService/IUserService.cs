using System.Collections.Generic;
using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeService
{
    public interface IUserService
    {
        public RegisteredUserDTO GetUser(int id);
        public IEnumerable<RegisteredUserDTO> GetAllUsers();
        public RegisteredUserDTO RegisterUser(NewUserDTO userDto);
    }
}