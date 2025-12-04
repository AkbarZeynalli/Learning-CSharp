namespace CMSApp.WebAPI.Dtos
{
    public record EnrollmentDto : BaseDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Grade { get; set; }
    }
}
