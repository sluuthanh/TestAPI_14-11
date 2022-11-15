using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class District
    {
        public District()
        {
            CityDistricts = new HashSet<CityDistrict>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string District1 { get; set; }

        public virtual ICollection<CityDistrict> CityDistricts { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
