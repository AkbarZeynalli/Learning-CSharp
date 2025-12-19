using AutoMapper;
using Pharmacy.BLL.Dtos;
using Pharmacy.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Mapper
{
    public class CustomProfile : Profile
    {
        public CustomProfile()
        {   
            CreateMap<Drug, DrugDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
