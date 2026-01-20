using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record PrescriptionDto :BaseDto
    {
        public int PatientId { get; init; }
        public int DoctorId { get; init; }
        public int AppointmentId { get; init; }
        public string Medications { get; init; } = string.Empty;
        public string? GeneralInstructions { get; init; }
        public string? DietaryAdvice { get; init; }
        public DateTime IssueDate { get; init; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; init; }
        public string? PdfUrl { get; init; }
        public bool IsActive { get; init; } = true;
    }
}
