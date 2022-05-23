using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeService;
using TicTacToeWebApi.Hubs.Clients;

namespace TicTacToeWebApi.Hubs
{
    public class PlayerMoveHub : Hub<IPlayerMoveClient>
    {
        private readonly IGameService _gameService;

        public PlayerMoveHub(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task SendGame(GameDTO gameDto)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, gameDto.RoomId);
            Game newGame = _gameService.CreateGame(new Game(
                gameDto.Outcome == 0 ? Outcome.X : gameDto.Outcome == 1 ? Outcome.O : Outcome.DRAW, gameDto.PlayerId));
            await Clients.Caller.ReceiveGame(newGame);
        }

        public async Task SendPlayerMove(GameDTO gameDto)
        {
            await Clients.Group(gameDto.RoomId).RecievePlayerMove(gameDto);
        }
    }
}