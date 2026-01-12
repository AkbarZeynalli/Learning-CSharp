using AutoMapper;
using FoodWasteApp.BLL.Dtos;
using FoodWasteApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Mapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<FoodItem,FoodItemDto>().ReverseMap();
            CreateMap<Reservation,ReservationDto>().ReverseMap();
            CreateMap<Restaurant,RestaurantDto>().ReverseMap();
            CreateMap<Review,ReviewDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
