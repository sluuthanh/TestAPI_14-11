using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Metacombobox
    {
        public Metacombobox()
        {
            InverseParent = new HashSet<Metacombobox>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string ExternalCode { get; set; }
        public string NameMeta { get; set; }
        public int? Sort { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? StatusId { get; set; }

        public virtual Metacombobox Parent { get; set; }
        public virtual ICollection<Metacombobox> InverseParent { get; set; }
    }
}
