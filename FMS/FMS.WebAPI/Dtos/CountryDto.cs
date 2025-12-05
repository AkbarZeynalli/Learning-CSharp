namespace FMS.WebAPI.Dtos
{
    public record CountryDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
