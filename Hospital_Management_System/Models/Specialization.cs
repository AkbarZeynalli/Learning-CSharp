using Hospital_Management_System.Models;

public class Specialization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public List<Doctor> Doctors { get; set; }
}
