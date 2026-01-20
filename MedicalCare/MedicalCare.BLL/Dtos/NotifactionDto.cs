using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.BLL.Dtos
{
    public record NotifactionDto :BaseDto
    {
        public int UserId { get; init; }
        public string Type { get; init; } = string.Empty;
        public string Title { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public bool IsRead { get; init; } = false;
        public DateTime? ReadAt { get; init; }
        public int? RelatedEntityId { get; init; }
        public string? RelatedEntityType { get; init; }
        public string? ActionUrl { get; init; }
        public DateTime SentDate { get; init; } = DateTime.UtcNow;
    }
}
