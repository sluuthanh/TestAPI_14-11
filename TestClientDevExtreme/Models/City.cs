namespace TestClientDevExtreme.Models
{
    public partial class City
    {
        public City()
        {
            CityDistricts = new HashSet<CityDistrict>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }

        public virtual ICollection<CityDistrict> CityDistricts { get; set; }
    }
}
