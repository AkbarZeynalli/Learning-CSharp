using AutoMapper;
using MedicalCare.BLL.Dtos;
using MedicalCare.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Mapper
{
    public class CustomProfile :Profile
    {
        public CustomProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Doctor,DoctorDto>().ReverseMap();
            CreateMap<DoctorSchedule,DoctorScheduleDto>().ReverseMap();
            CreateMap<MedicalRecord, MedicalRecordDto>().ReverseMap();
            CreateMap<Medication, MedicationDto>().ReverseMap();
            CreateMap<Notification, NotifactionDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Prescription, PrescriptionDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
