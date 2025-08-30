using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem
{
    internal class Assignment
    {
        public int AssignmentId { get; set; }             
        public string Title { get; set; }         
        public string Description { get; set; }       
        public DateTime DueDate { get; set; }       
        public int CourseId { get; set; }            
        public int TeacherId { get; set; }            
        public double MaxScore { get; set; }
    }
}
