namespace TestClientDevExtreme.Models
{
    public partial class Student
    {
        public int SchedulerId { get; set; }
        public DateTime DoB { get; set; }
        public string Name { get; set; }
        public string ClassStudent { get; set; }
        public string HinhAnh { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
    }
}
