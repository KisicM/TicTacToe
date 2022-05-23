using System.Collections.Generic;
using AutoMapper;
using TicTacToeDomain;
using TicTacToeDTO;
using TicTacToeRepository;

namespace TicTacToeService.Impl
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public Game CreateGame(Game game)
        {
            return _gameRepository.Insert(game);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _gameRepository.GetAll();
        }

        public Game GetGame(int id)
        {
            return _gameRepository.GetById(id);
        }

        public Game UpdateWinner(GameDTO gameDto)
        {
            return _gameRepository.UpdateWinner(_mapper.Map<Game>(gameDto));
        }

    }
}