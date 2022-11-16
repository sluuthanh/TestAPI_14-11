namespace TestClientDevExtreme.Models.DTO
{
    public class StudentSearchDTO
    {
        public DateTime DoB { get; set; }
        public string Name { get; set; }
        public string ClassStudent { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
    }
}
