using System;
using System.Collections.Generic;

namespace SManagmentSystem.Models
{
    internal class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Credits { get; set; }

        // Hər kursun bir müəllimi olur
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;

        // Kursa yazılmış tələbələr
        public ICollection<Student> Students { get; set; } = new List<Student>();

        // Kursun mövzuları (məsələn: SQL Basics, Joins, Transactions və s.)
        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
