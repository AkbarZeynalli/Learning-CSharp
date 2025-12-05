using AutoMapper;
using FMS.DAL.Models;
using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Club, ClubDto>().ReverseMap();
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<League, LeaugeDto>().ReverseMap();
            CreateMap<Goal,GoalDto>().ReverseMap();
        }
    }
}
