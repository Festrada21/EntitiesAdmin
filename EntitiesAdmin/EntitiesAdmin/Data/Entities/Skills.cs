using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Skills
    {
        public Skills()
        {
            Employees = new HashSet<Employees>();
        }

        public int SkillId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime? EditionDate { get; set; }

        public virtual Departments Department { get; set; }
        public virtual StatusFields StatusField { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
