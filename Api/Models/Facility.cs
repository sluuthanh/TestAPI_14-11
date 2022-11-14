using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Facility
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
    }
}
