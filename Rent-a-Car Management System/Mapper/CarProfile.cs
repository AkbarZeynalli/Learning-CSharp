using AutoMapper;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;

namespace Rent_a_Car_Management_System.Mapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<CarModel, CarModelDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Rental, RentalDto>().ReverseMap();
        }
    }
}
