using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models.Enums
{
    public enum AppointmentStatus
    {
        Pending = 0,       // Gözləyir (həkim təsdiq etməyib)
        Confirmed = 1,     // Təsdiqlənib
        Cancelled = 2,     // Ləğv edilib
        Completed = 3,     // Tamamlanıb
        NoShow = 4         // Xəstə gəlməyib
    }
}
