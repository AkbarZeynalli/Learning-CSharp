using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem
{
    internal class Grade
    {
        public int GradeId { get; set; }             
        public int StudentId { get; set; }       
        public int AssignmentId { get; set; }    
        public double Score { get; set; }        
        public string Feedback { get; set; }    
        public DateTime GradedDate { get; set; }
    }
}
