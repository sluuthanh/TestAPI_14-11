namespace TestClientDevExtreme.Models
{
    public partial class Student
    {
       public int SchedulerId { get; set; }
        public DateTime? DoB { get; set; }
        public string Name { get; set; }
        public string ClassStudent { get; set; }
        public string HinhAnh { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? PermanentProvinceId { get; set; }
        public int? PermanentDistrictId { get; set; }
        public int? PermanentWardId { get; set; }
        public string PermanentAddress { get; set; }
        public int? TemporaryProvinceId { get; set; }
        public int? TemporaryDistrictId { get; set; }
        public int? TemporaryWardId { get; set; }
        public string TemporaryAddress { get; set; }

    }
}
