using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class DoctorSchedule : BaseEntity
    {
        public int DoctorId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int SlotDuration { get; set; } = 30;
        public bool IsAvailable { get; set; } = true;
        public string? Notes { get; set; }

        // Navigation Property
        public virtual Doctor Doctor { get; set; } = null!;
    }
}
