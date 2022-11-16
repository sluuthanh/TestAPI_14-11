using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Api.Models
{
    public partial class Student
    {
        public int SchedulerId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
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
