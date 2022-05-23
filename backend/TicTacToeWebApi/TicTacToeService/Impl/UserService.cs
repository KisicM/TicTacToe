using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Npgsql.TypeMapping;
using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeRepository;
using TicTacToeService;

namespace TicTacToeService.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository testUserRepository, IMapper mapper)
        {
            _userRepository = testUserRepository;
            _mapper = mapper;
        }

        public IEnumerable<RegisteredUserDTO> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<RegisteredUserDTO>>(_userRepository.GetAll());
        }

        public RegisteredUserDTO GetUser(int id)
        {
            return _mapper.Map<RegisteredUserDTO>(_userRepository.GetById(id));
        }

        public RegisteredUserDTO RegisterUser(NewUserDTO userDto)
        {
            User newUser = _userRepository.Insert(_mapper.Map<User>(userDto));
            if (newUser == null)
                return null;
            return _mapper.Map<RegisteredUserDTO>(newUser);
        }
    }
}