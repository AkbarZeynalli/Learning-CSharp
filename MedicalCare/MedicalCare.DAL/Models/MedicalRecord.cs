using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class MedicalRecord : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; } = string.Empty;
        public string? Treatment { get; set; }
        public string? Notes { get; set; }

        // Vital Signs
        public string? BloodPressure { get; set; }
        public int? PulseRate { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? OxygenSaturation { get; set; }

        public string? AttachmentUrls { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string? FollowUpNotes { get; set; }

        // Navigation Properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Appointment Appointment { get; set; } = null!;
    }
}
