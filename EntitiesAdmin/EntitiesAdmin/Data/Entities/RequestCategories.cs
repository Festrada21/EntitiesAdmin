using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class RequestCategories
    {
        public RequestCategories()
        {
            TypeRequests = new HashSet<TypeRequests>();
        }

        public int RequestCategoryId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime EditionDate { get; set; }

        public virtual StatusFields StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TypeRequests> TypeRequests { get; set; }
    }
}
