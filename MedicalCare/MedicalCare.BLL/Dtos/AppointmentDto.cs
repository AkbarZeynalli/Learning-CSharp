using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record AppointmentDto : BaseDto
    {
        public int PatientId { get; init; }
        public int DoctorId { get; init; }

        public DateTime AppointmentDate { get; init; }
        public TimeSpan TimeSlot { get; init; }

        public AppointmentType Type { get; init; }
        public AppointmentStatus Status { get; init; }

        public string Reason { get; init; } = string.Empty;
        public string? Symptoms { get; init; }
        public string? ConsultationNotes { get; init; }

        public decimal Amount { get; init; }
        public PaymentStatus PaymentStatus { get; init; }

        public string? VideoCallLink { get; init; }
        public DateTime? CompletedAt { get; init; }
    }
}
