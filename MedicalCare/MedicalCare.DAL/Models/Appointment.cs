using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan TimeSlot { get; set; }
        public AppointmentType Type { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
        public string Reason { get; set; } = string.Empty;
        public string? Symptoms { get; set; }
        public string? ConsultationNotes { get; set; }
        public string? CancellationReason { get; set; }
        public DateTime? CancelledAt { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public string? VideoCallLink { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Navigation Properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual MedicalRecord? MedicalRecord { get; set; }
        public virtual Prescription? Prescription { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
