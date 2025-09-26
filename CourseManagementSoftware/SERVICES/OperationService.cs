using CourseManagementSoftware.DATA;
using CourseManagementSoftware.MODELS;
using System;

namespace CourseManagementSoftware.SERVICES
{
    internal class OperationService
    {
        private AppDbContext appContext;

        public OperationService()
        {
            appContext = new AppDbContext();
        }

        public void AddGroup()
        {
            Group group = new Group();

            Console.Write("Enter group code: ");
            group.Code = Console.ReadLine();

            Console.Write("Enter group name: ");
            group.Name = Console.ReadLine();

            appContext.Groups.Add(group);
            appContext.SaveChanges();

            Console.WriteLine("Group successfully added!");
        }

        public void AddTeacher()
        {
            Teacher teacher = new Teacher();

            Console.Write("Enter teacher no (1-100): ");
            int no = int.Parse(Console.ReadLine());

            // 1–100 aralığını yoxlayaq
            if (no < 1 || no > 100)
            {
                Console.WriteLine("❌ Teacher number must be between 1 and 100.");
                return;
            }

            // Əgər həmin nömrə artıq varsa
            if (appContext.Teachers.Any(t => t.TeacherNo == no))
            {
                Console.WriteLine("❌ This teacher number already exists!");
                return;
            }

            teacher.TeacherNo = no;

            Console.Write("Enter teacher first name: ");
            teacher.Name = Console.ReadLine();

            Console.Write("Enter teacher Surname: ");
            teacher.Surname = Console.ReadLine();
            Console.Write("Enter teacher Phone Number: ");
            teacher.PhoneNumber = Console.ReadLine();
            Console.Write("Enter teacher Email: ");
            teacher.Email = Console.ReadLine();
            Console.Write("Enter teacher Address: ");
            teacher.Address = Console.ReadLine();

            appContext.Teachers.Add(teacher);
            appContext.SaveChanges();

            Console.WriteLine(" Teacher successfully added!");
        }

        public void AddMentor()
        {
            Mentor mentor = new Mentor();
            Console.Write("Enter mentor no (1-100): ");
            int no = int.Parse(Console.ReadLine());
            // 1–100 aralığını yoxlayaq
            if (no < 1 || no > 100)
            {
                Console.WriteLine("❌ Mentor number must be between 1 and 100.");
                return;
            }
            // Əgər həmin nömrə artıq varsa
            if (appContext.Mentors.Any(m => m.MentorNo == no))
            {
                Console.WriteLine("❌ This mentor number already exists!");
                return;
            }
            mentor.MentorNo = no;
            Console.Write("Enter mentor first name: ");
            mentor.Name = Console.ReadLine();
            Console.Write("Enter mentor Surname: ");
            mentor.Surname = Console.ReadLine();
            Console.Write("Enter mentor Phone Number: ");
            mentor.PhoneNumber = Console.ReadLine();
            Console.Write("Enter mentor Email: ");
            mentor.Email = Console.ReadLine();
            Console.Write("Enter mentor Address: ");
            mentor.Address = Console.ReadLine();
            appContext.Mentors.Add(mentor);
            appContext.SaveChanges();
            Console.WriteLine(" Mentor successfully added!");
        }

        public void AddStudent()
        {
            Student student = new Student();
            Console.Write("Enter student no (1-100): ");
            int no = int.Parse(Console.ReadLine());
            // 1–100 aralığını yoxlayaq
            if (no < 1 || no > 100)
            {
                Console.WriteLine("❌ Student number must be between 1 and 100.");
                return;
            }
            // Əgər həmin nömrə artıq varsa
            if (appContext.Students.Any(s => s.StudentNo == no))
            {
                Console.WriteLine("❌ This student number already exists!");
                return;
            }
            student.StudentNo = no;
            Console.Write("Enter student first name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter student Surname: ");
            student.Surname = Console.ReadLine();
            Console.Write("Enter student Phone Number: ");
            student.PhoneNumber = Console.ReadLine();
            Console.Write("Enter student Email: ");
            student.Email = Console.ReadLine();
            Console.Write("Enter student Address: ");
            student.Address = Console.ReadLine();
            appContext.Students.Add(student);
            appContext.SaveChanges();
            Console.WriteLine(" Student successfully added!");

        }

        public void AssignTeacherToGroup()
        {
            // Bütün mövcud müəllimləri göstər
            var teachers = appContext.Teachers.ToList();
            Console.WriteLine("Available Teachers:");
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.Name} {teacher.Surname}, Teacher No: {teacher.TeacherNo}");
            }
            // İstifadəçidən müəllim ID-sini soruş
            Console.Write("Enter the ID of the teacher to assign: ");
            int teacherId = int.Parse(Console.ReadLine());
            // Bütün mövcud qrupları göstər
            var groups = appContext.Groups.ToList();
            Console.WriteLine("Available Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Code: {group.Code}, Name: {group.Name}");
            }
            // İstifadəçidən qrup ID-sini soruş
            Console.Write("Enter the ID of the group to assign the teacher to: ");
            int groupId = int.Parse(Console.ReadLine());
            // Müvafiq müəllimi və qrupu tap
            var selectedTeacher = appContext.Teachers.Find(teacherId);
            var selectedGroup = appContext.Groups.Find(groupId);
            if (selectedTeacher == null || selectedGroup == null)
            {
                Console.WriteLine("❌ Invalid teacher or group ID.");
                return;
            }
            // Müəllimi qrupa təyin et
            selectedGroup.TeacherId = selectedTeacher.Id;
            appContext.SaveChanges();
            Console.WriteLine($"✅ Teacher {selectedTeacher.Name} {selectedTeacher.Surname} assigned to group {selectedGroup.Code} successfully!");
        }

        public void AssignMentorToGroup()
        {
            // Bütün mövcud mentorları göstər
            var mentors = appContext.Mentors.ToList();
            Console.WriteLine("Available Mentors:");
            foreach (var mentor in mentors)
            {
                Console.WriteLine($"ID: {mentor.Id}, Name: {mentor.Name} {mentor.Surname}, Mentor No: {mentor.MentorNo}");
            }
            // İstifadəçidən mentor ID-sini soruş
            Console.Write("Enter the ID of the mentor to assign: ");
            int mentorId = int.Parse(Console.ReadLine());
            // Bütün mövcud qrupları göstər
            var groups = appContext.Groups.ToList();
            Console.WriteLine("Available Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Code: {group.Code}, Name: {group.Name}");
            }
            // İstifadəçidən qrup ID-sini soruş
            Console.Write("Enter the ID of the group to assign the mentor to: ");
            int groupId = int.Parse(Console.ReadLine());
            // Müvafiq mentoru və qrupu tap
            var selectedMentor = appContext.Mentors.Find(mentorId);
            var selectedGroup = appContext.Groups.Find(groupId);
            if (selectedMentor == null || selectedGroup == null)
            {
                Console.WriteLine("❌ Invalid mentor or group ID.");
                return;
            }
            // Mentoru qrupa təyin et
            selectedGroup.MentorId = selectedMentor.Id;
            appContext.SaveChanges();
            Console.WriteLine($"✅ Mentor {selectedMentor.Name} {selectedMentor.Surname} assigned to group {selectedGroup.Code} successfully!");
        }

        public void AssignStudentToGroup()
        {
            // Bütün mövcud tələbələri göstər
            var students = appContext.Students.ToList();
            Console.WriteLine("Available Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name} {student.Surname}, Student No: {student.StudentNo}");
            }
            // İstifadəçidən tələbə ID-sini soruş
            Console.Write("Enter the ID of the student to assign: ");
            int studentId = int.Parse(Console.ReadLine());
            // Bütün mövcud qrupları göstər
            var groups = appContext.Groups.ToList();
            Console.WriteLine("Available Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Code: {group.Code}, Name: {group.Name}");
            }
            // İstifadəçidən qrup ID-sini soruş
            Console.Write("Enter the ID of the group to assign the student to: ");
            int groupId = int.Parse(Console.ReadLine());
            // Müvafiq tələbəni və qrupu tap
            var selectedStudent = appContext.Students.Find(studentId);
            var selectedGroup = appContext.Groups.Find(groupId);
            if (selectedStudent == null || selectedGroup == null)
            {
                Console.WriteLine("❌ Invalid student or group ID.");
                return;
            }
            // Tələbəni qrupa təyin et
            if (!selectedGroup.StudentIds.Contains(selectedStudent.Id))
            {
                selectedGroup.StudentIds.Add(selectedStudent.Id);
                appContext.SaveChanges();
                Console.WriteLine($"✅ Student {selectedStudent.Name} {selectedStudent.Surname} assigned to group {selectedGroup.Code} successfully!");
            }
            else
            {
                Console.WriteLine("❌ This student is already assigned to the selected group.");
            }
        }

    }
}
