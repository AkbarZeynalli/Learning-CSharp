using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models.Enums
{
    public enum BloodType
    {
        APositive = 0,     // A+
        ANegative = 1,     // A-
        BPositive = 2,     // B+
        BNegative = 3,     // B-
        ABPositive = 4,    // AB+
        ABNegative = 5,    // AB-
        OPositive = 6,     // O+
        ONegative = 7,     // O-
        Unknown = 99
    }
}
