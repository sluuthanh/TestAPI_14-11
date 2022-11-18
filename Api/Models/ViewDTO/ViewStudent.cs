namespace Api.Models.ViewDTO
{
    public class ViewStudent
    {
        public int SchedulerId { get; set; }
        public DateTime DoB { get; set; }
        public string Name { get; set; }
        public string ClassStudent { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }

    }
}
