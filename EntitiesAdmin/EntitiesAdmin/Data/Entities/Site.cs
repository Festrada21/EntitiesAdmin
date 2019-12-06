using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Site
    {
        public Site()
        {
            Employees = new HashSet<Employee>();
        }

        public int SiteId { get; set; }
        public int? CountryId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime EditionDate { get; set; }

        public virtual Country Country { get; set; }
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
