using System.Collections.Generic;
using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeService
{
    public interface IPlayerRoomSerivce
    {
        public IEnumerable<PlayerRoom> GetAll();
        public PlayerRoom GetByName(string name);
        public PlayerRoom Create(PlayerRoomDTO playerRoomDto);
        public PlayerRoom Update(PlayerRoom playerRoom);
        public void Delete(int id);
    }
}