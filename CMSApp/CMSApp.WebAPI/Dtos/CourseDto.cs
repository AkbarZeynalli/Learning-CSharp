namespace CMSApp.WebAPI.Dtos
{
    public record CourseDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
    }
}
