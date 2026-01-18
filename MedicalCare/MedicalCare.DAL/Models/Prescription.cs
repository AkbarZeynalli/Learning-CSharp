using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Prescription : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public string Medications { get; set; } = string.Empty;
        public string? GeneralInstructions { get; set; }
        public string? DietaryAdvice { get; set; }
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public string? PdfUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Appointment Appointment { get; set; } = null!;
    }
}
