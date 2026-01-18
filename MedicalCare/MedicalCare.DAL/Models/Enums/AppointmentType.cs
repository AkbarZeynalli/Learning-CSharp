using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models.Enums
{
    public enum AppointmentType
    {
        InPerson = 0,      // Fiziki görüş
        VideoCall = 1,     // Online video konsultasiya
        PhoneCall = 2      // Telefon konsultasiyası
    }
}
