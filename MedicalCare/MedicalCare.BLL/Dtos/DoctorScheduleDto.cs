using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record DoctorScheduleDto : BaseDto
    {
        public int DoctorId { get; init; }
        public DayOfWeek DayOfWeek { get; init; }
        public TimeSpan StartTime { get; init; }
        public TimeSpan EndTime { get; init; }
        public int SlotDuration { get; init; } = 30;
        public bool IsAvailable { get; init; } = true;
        public string? Notes { get; init; }
    }
}
