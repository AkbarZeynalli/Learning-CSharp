using System;
using System.Collections.Generic;

namespace StudentManagmentSystem.Models
{
    internal class Course 
    {
        // Name property əlavə olundu (çünki error bunu tələb edir)
        public string Name { get; set; } = string.Empty;

        // CS8618 error-unun qarşısını almaq üçün default dəyərlər verdim
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Credits { get; set; }

        public Teacher Teacher { get; set; } = null!; // ! ilə null-un qarşısı alınır
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
