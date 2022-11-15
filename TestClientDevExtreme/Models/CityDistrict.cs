using TestClientDevExtreme.Models;

namespace TestClientDevExtreme
{
    public partial class CityDistrict
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
    }
}