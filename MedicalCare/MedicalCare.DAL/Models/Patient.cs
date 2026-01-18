using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Patient :User
    {
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public BloodType? BloodType { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? InsuranceProvider { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? Allergies { get; set; }
        public string? ChronicConditions { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

        // Navigation Properties
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
