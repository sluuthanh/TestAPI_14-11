using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
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

        public virtual City City { get; set; }
        public virtual District District { get; set; }
    }
}
