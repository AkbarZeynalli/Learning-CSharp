using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem
{
    internal class Store
    {
        public List<Course> CourseList { get; set; } = new List<Course>();

        public List<Group> GroupList { get; set; } = new List<Group>();
        public List<Student> StudentList { get; set; } = new List<Student>();
        public List<Teacher> TeacherList { get; set; } = new List<Teacher>();
        public List<Assignment> AssignmentList { get; set; } = new List<Assignment>();
        public List<Grade> GradeList { get; set; } = new List<Grade>();

        public Store() { 
            CourseList = new List<Course>();
            GroupList = new List<Group>();
            StudentList = new List<Student>();
            TeacherList = new List<Teacher>();
            AssignmentList = new List<Assignment>();
            GradeList = new List<Grade>();
        }
    }
}
