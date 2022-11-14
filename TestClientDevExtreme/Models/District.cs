namespace TestClientDevExtreme
{
    public partial class District
    {
        public District()
        {
            CityDistricts = new HashSet<CityDistrict>();
        }

        public int Id { get; set; }
        public string District1 { get; set; }

        public virtual ICollection<CityDistrict> CityDistricts { get; set; }
    }
}