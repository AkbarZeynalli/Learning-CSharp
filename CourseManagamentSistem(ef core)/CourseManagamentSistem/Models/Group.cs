using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem.Models
{
    internal class Group : BaseEntity
    {
        public string GroupName { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
