using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record ReviewDto :BaseDto
    {
        public int PatientId { get; init; }
        public int DoctorId { get; init; }
        public int AppointmentId { get; init; }
        public int Rating { get; init; }
        public string? Comment { get; init; }
        public string? DoctorResponse { get; init; }
        public DateTime? ResponseDate { get; init; }
        public bool IsVerified { get; init; } = false;
        public int HelpfulCount { get; init; } = 0;
        public bool IsReported { get; init; } = false;
        public string? ReportReason { get; init; }
    }
}
