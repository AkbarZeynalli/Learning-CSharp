using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record PaymentDto : BaseDto
    {
        public int AppointmentId { get; init; }
        public int PatientId { get; init; }
        public int DoctorId { get; init; }
        public decimal Amount { get; init; }
        public decimal PlatformFee { get; init; }
        public decimal DoctorEarnings { get; init; }
        public string PaymentMethod { get; init; } = "Card";
        public string? TransactionId { get; init; }
        public PaymentStatus Status { get; init; } = PaymentStatus.Pending;
        public DateTime? PaidAt { get; init; }
        public DateTime? RefundedAt { get; init; }
        public string? RefundReason { get; init; }
        public decimal? RefundAmount { get; init; }
        public string? Notes { get; init; }
    }
}
