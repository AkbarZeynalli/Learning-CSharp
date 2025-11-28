using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;

namespace Hospital_Management_System.Mapper
{
    public class HospitalProfile : Profile
    {
        public HospitalProfile()
        {
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Specialization, SpecializationDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
        }
    }
}
