using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Doctor : User
    {
        public string LicenseNumber { get; set; } = string.Empty;
        public Specialization Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public string Degree { get; set; } = string.Empty;
        public string? MedicalSchool { get; set; }
        public string? About { get; set; }
        public string? ClinicAddress { get; set; }
        public decimal ConsultationFee { get; set; }
        public decimal VideoCallFee { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public bool IsVerified { get; set; } = false;
        public DateTime? VerificationDate { get; set; }
        public string? RejectionReason { get; set; }
        public decimal AverageRating { get; set; } = 0;
        public int TotalReviews { get; set; } = 0;
        public int TotalAppointments { get; set; } = 0;
        public int CompletedAppointments { get; set; } = 0;
        public decimal TotalEarnings { get; set; } = 0;

        // Navigation Properties
        public virtual ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Payment> PaymentsReceived { get; set; } = new List<Payment>();
    }
}
