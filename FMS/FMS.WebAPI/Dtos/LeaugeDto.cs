namespace FMS.WebAPI.Dtos
{
    public record LeaugeDto : BaseDto
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
