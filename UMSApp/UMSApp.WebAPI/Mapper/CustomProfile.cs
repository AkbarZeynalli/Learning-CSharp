using AutoMapper;
using UMSApp.DAL.Models;
using UMSApp.WebAPI.Dtos;

namespace UMSApp.WebAPI.Mapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<University, UniversityDto>().ReverseMap();
        }
    }
}
