using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeRepository;

namespace TicTacToeService.Impl
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;

        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUsingCredentials(LoginDTO loginDTO)
        {
            return _userRepository.GetUsingCredentials(loginDTO.Username, loginDTO.Password);
        }
    }
}