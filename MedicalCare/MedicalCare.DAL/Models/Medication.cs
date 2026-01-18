using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Medication : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? GenericName { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Strength { get; set; }
        public string? Manufacturer { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? SideEffects { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
