using System;

namespace SManagmentSystem.Models
{
    internal class Topic : BaseEntity
    {
        public string Title { get; set; } = string.Empty;       // Mövzu başlığı
        public string Description { get; set; } = string.Empty; // Mövzu haqqında məlumat

        // Hər mövzu bir kursa aiddir
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}
