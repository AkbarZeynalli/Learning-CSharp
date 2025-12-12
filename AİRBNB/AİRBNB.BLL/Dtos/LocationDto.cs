namespace AİRBNB.BLL.Dtos
{
    public record LocationDto : BaseDto
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
