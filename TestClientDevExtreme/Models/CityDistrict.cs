using TestClientDevExtreme.Models;
namespace TestClientDevExtreme.Models
{
    public partial class CityDistrict
    {
        public int Id { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
    }
}