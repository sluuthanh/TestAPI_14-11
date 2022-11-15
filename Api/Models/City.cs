using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class City
    {
        public City()
        {
            CityDistricts = new HashSet<CityDistrict>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string City1 { get; set; }

        public virtual ICollection<CityDistrict> CityDistricts { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
