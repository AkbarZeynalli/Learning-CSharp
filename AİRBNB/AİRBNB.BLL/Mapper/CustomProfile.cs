using AİRBNB.BLL.Dtos;
using AİRBNB.DAL.Models;
using AutoMapper;

namespace AİRBNB.BLL.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Booking, BookingDto>().ReverseMap();
        }
    }
}
