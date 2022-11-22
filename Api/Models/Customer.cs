using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fullname { get; set; }
        public string FullnameDisplay { get; set; }
        public string Avatar { get; set; }
        public byte? GenderId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public int? PermanentProvinceId { get; set; }
        public int? PermanentDistrictId { get; set; }
        public int? PermanentWardId { get; set; }
        public string PermanentAddress { get; set; }
        public int? TemporaryProvinceId { get; set; }
        public int? TemporaryDistrictId { get; set; }
        public int? TemporaryWardId { get; set; }
        public string TemporaryAddress { get; set; }
        public int? StatusId { get; set; }
        public bool? IsActive { get; set; }
    }
}
