using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class TypeRequests
    {
        public TypeRequests()
        {
            Requests = new HashSet<Requests>();
        }

        public int TypeRequestId { get; set; }
        public int? DepartmentId { get; set; }
        public int? RequestCategoryId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime EditionDate { get; set; }

        public virtual Departments Department { get; set; }
        public virtual RequestCategories RequestCategory { get; set; }
        public virtual StatusFields StatusField { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
    }
}
