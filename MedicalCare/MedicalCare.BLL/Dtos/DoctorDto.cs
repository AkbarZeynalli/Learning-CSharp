using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record DoctorDto : UserDto
    {
        public string LicenseNumber { get; init; } = string.Empty;
        public Specialization Specialization { get; init; }
        public int YearsOfExperience { get; init; }
        public string Degree { get; init; } = string.Empty;
        public string? MedicalSchool { get; init; }
        public string? About { get; init; }
        public string? ClinicAddress { get; init; }
        public decimal ConsultationFee { get; init; }
        public decimal VideoCallFee { get; init; }
        public string? BankAccountNumber { get; init; }
        public string? BankName { get; init; }
        public bool IsVerified { get; init; } = false;
        public DateTime? VerificationDate { get; init; }
        public string? RejectionReason { get; init; }
        public decimal AverageRating { get; init; } = 0;
        public int TotalReviews { get; init; } = 0;
        public int TotalAppointments { get; init; } = 0;
        public int CompletedAppointments { get; init; } = 0;
        public decimal TotalEarnings { get; init; } = 0;
    }
}
