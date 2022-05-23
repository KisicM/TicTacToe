using AutoMapper;
using System.Collections.Generic;
using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeRepository;

namespace TicTacToeService.Impl
{
    public class PlayerRoomService : IPlayerRoomSerivce
    {
        private readonly IPlayerRoomRepository _playerRoomRepository;
        private readonly IMapper _mapper;

        public PlayerRoomService(IPlayerRoomRepository playerRoomRepository, IMapper mapper)
        {
            _playerRoomRepository = playerRoomRepository;
            _mapper = mapper;
        }

        public PlayerRoom Create(PlayerRoomDTO playerRoomDto)
        {
            return _playerRoomRepository.Insert(_mapper.Map<PlayerRoom>(playerRoomDto));
        }

        public void Delete(int id)
        {
            PlayerRoom room = _playerRoomRepository.GetById(id);
            _playerRoomRepository.Delete(room);
        }

        public IEnumerable<PlayerRoom> GetAll()
        {
            return _playerRoomRepository.GetAll();
        }

        public PlayerRoom GetByName(string name)
        {
            PlayerRoom room = _playerRoomRepository.GetByName(name);
            return room;
        }

        public PlayerRoom Update(PlayerRoom playerRoom)
        {
            return _playerRoomRepository.Update(playerRoom);
        }
    }
}