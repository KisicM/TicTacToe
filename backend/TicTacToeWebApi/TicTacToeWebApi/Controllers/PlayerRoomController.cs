using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeService;

namespace TicTacToeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PlayerRoomController : Controller
    {
        private readonly IPlayerRoomSerivce _playerRoomSerivce;

        public PlayerRoomController(IPlayerRoomSerivce playerRoomSerivce)
        {
            _playerRoomSerivce = playerRoomSerivce;
        }

        [HttpGet]
        public IEnumerable<PlayerRoom> GetAll()
        {
            return _playerRoomSerivce.GetAll();
        }

        [HttpGet]
        [Route("{name}")]
        public PlayerRoom GetByName(string name)
        {
            return _playerRoomSerivce.GetByName(name);
        }

        [HttpPost]
        public PlayerRoom Create(PlayerRoomDTO playerRoomDto)
        {
            return _playerRoomSerivce.Create(playerRoomDto);
        }

        [HttpPut]
        public PlayerRoom Update(PlayerRoom playerRoom)
        {
            return _playerRoomSerivce.Update(playerRoom);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            _playerRoomSerivce.Delete(id);
            return true;
        }
    }
}
