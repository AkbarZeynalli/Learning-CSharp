using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record MedicalRecordDto : BaseDto
    {
        public int PatientId { get; init; }
        public int DoctorId { get; init; }
        public int AppointmentId { get; init; }
        public string Diagnosis { get; init; } = string.Empty;
        public string? Treatment { get; init; }
        public string? Notes { get; init; }

        // Vital Signs
        public string? BloodPressure { get; init; }
        public int? PulseRate { get; init; }
        public decimal? Temperature { get; init; }
        public decimal? Weight { get; init; }
        public decimal? Height { get; init; }
        public int? OxygenSaturation { get; init; }

        public string? AttachmentUrls { get; init; }
        public DateTime? FollowUpDate { get; init; }
        public string? FollowUpNotes { get; init; }
    }
}
