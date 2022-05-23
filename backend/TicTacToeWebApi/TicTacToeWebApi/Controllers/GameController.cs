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
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return _gameService.GetAllGames();
        }

        [HttpGet]
        [Route("{id}")]
        public Game Get(int id)
        {
            return _gameService.GetGame(id);
        }

        [HttpPut]
        public Game Update(GameDTO gameDto)
        {
            return _gameService.UpdateWinner(gameDto);
        }
    }
}
