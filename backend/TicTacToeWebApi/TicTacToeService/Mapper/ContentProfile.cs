using AutoMapper;
using TicTacToeDomain;
using TicTacToeDTO;

namespace TicTacToeService.Mapper
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<NewUserDTO, User>().ConstructUsing(x => new User(x.Username, x.Password, x.Name, x.Surname, x.Email)).ReverseMap();
            CreateMap<User, RegisteredUserDTO>().ReverseMap();
            CreateMap<Game, GameDTO>().ReverseMap();
            CreateMap<PlayerRoom, PlayerRoomDTO>().ReverseMap();
        }

    }
}