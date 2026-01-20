using MedicalCare.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record UserDto : BaseDto
    {
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string PasswordHash { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;
        public UserRole Role { get; init; }
        public string? ProfilePhotoUrl { get; init; }
        public bool IsActive { get; init; } = true;
        public bool EmailConfirmed { get; init; } = false;
        public DateTime? LastLoginAt { get; init; }
        public string? Address { get; init; }
        public string? City { get; init; }
        public string? Country { get; init; }
        public double? Latitude { get; init; }
        public double? Longitude { get; init; }
    }
}
