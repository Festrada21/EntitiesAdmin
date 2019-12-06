using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Departments
    {
        public Departments()
        {
            Skills = new HashSet<Skills>();
            TypeRequests = new HashSet<TypeRequests>();
        }

        public int DepartmentId { get; set; }
        public int RosterId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime? EditionDate { get; set; }

        public virtual Rosters Roster { get; set; }
        public virtual StatusFields StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<TypeRequests> TypeRequests { get; set; }
    }
}
