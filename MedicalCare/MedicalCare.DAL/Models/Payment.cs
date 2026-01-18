using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Payment : BaseEntity
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public decimal Amount { get; set; }
        public decimal PlatformFee { get; set; }
        public decimal DoctorEarnings { get; set; }
        public string PaymentMethod { get; set; } = "Card";
        public string? TransactionId { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public DateTime? PaidAt { get; set; }
        public DateTime? RefundedAt { get; set; }
        public string? RefundReason { get; set; }
        public decimal? RefundAmount { get; set; }
        public string? Notes { get; set; }

        // Navigation Properties
        public virtual Appointment Appointment { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
