using AutoMapper;
using CMSApp.DAL.Models;
using CMSApp.WebAPI.Dtos;

namespace CMSApp.WebAPI.Mapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentDto>().ReverseMap();
            CreateMap<Instructor, InstructorDto>().ReverseMap();
        }
    }
}
