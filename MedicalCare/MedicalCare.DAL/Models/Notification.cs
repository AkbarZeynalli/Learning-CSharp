using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCare.DAL.Models
{
    public class Notification : BaseEntity
    {
        public int UserId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }
        public string? ActionUrl { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual User User { get; set; } = null!;
    }
}
