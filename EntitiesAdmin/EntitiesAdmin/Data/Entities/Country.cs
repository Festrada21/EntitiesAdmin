using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employee>();
            Site = new HashSet<Site>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime? EditionDate { get; set; }

        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Site> Site { get; set; }
    }
}
