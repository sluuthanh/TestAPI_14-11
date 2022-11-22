namespace TestClientDevExtreme.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Telephonecode { get; set; }
        public string Zipcode { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public int? Sortorder { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
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
