using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record MedicationDto :BaseDto
    {
        public string Name { get; init; } = string.Empty;
        public string? GenericName { get; init; }
        public string Type { get; init; } = string.Empty;
        public string? Strength { get; init; }
        public string? Manufacturer { get; init; }
        public decimal? Price { get; init; }
        public string? Description { get; init; }
        public string? SideEffects { get; init; }
        public bool IsActive { get; init; } = true;
    }
}
