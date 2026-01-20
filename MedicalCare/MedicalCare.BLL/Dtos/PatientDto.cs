using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record PatientDto :BaseDto
    {
        public DateTime DateOfBirth { get; init; }
        public Gender Gender { get; init; }
        public BloodType? BloodType { get; init; }
        public string? EmergencyContactName { get; init; }
        public string? EmergencyContactPhone { get; init; }
        public string? InsuranceProvider { get; init; }
        public string? InsuranceNumber { get; init; }
        public string? Allergies { get; init; }
        public string? ChronicConditions { get; init; }
        public decimal? Height { get; init; }
        public decimal? Weight { get; init; }
    }
}
