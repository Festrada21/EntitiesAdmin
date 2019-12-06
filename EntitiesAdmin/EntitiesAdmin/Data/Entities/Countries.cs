using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Countries
    {
        public Countries()
        {
            Employees = new HashSet<Employees>();
            Site = new HashSet<Site>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime? EditionDate { get; set; }

        public virtual StatusFields StatusField { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Site> Site { get; set; }
    }
}
