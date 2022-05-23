using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TicTacToeDTO;
using TicTacToeService;

namespace TicTacToeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService testUserService)
        {
            _userService = testUserService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<RegisteredUserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public RegisteredUserDTO GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        [AllowAnonymous]
        public RegisteredUserDTO RegisterUser(NewUserDTO userDto)
        {
            return _userService.RegisterUser(userDto);
        }
    }
}
