using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models.Enums
{
    public enum PaymentStatus
    {
        Pending = 0,       // Gözləyir
        Completed = 1,     // Ödənilib
        Failed = 2,        // Uğursuz
        Refunded = 3,      // Geri qaytarılıb
        Cancelled = 4      // Ləğv edilib
    }
}
