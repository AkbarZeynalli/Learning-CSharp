using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Review : BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public string? DoctorResponse { get; set; }
        public DateTime? ResponseDate { get; set; }
        public bool IsVerified { get; set; } = false;
        public int HelpfulCount { get; set; } = 0;
        public bool IsReported { get; set; } = false;
        public string? ReportReason { get; set; }

        // Navigation Properties
        public virtual Patient Patient { get; set; } = null!;
        public virtual Doctor Doctor { get; set; } = null!;
        public virtual Appointment Appointment { get; set; } = null!;
    }
}
