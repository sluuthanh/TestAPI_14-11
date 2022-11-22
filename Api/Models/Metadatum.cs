using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Metadatum
    {
        public long Id { get; set; }
        public int GroupId { get; set; }
        public string GroupText { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemText { get; set; }
        public string Description { get; set; }
        public int? Sort { get; set; }
        public bool? IsActive { get; set; }
        public string ExternalCode { get; set; }
        public int? OptimisticLockField { get; set; }
        public int? Gcrecord { get; set; }
        public string AuthorCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ApproverCode { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string UpdatedCode { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ApproverUpdateCode { get; set; }
        public DateTime? ApprovedUpdateDate { get; set; }
        public int? StatusId { get; set; }
    }
}
