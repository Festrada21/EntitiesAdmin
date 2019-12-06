using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class StatusFields
    {
        public StatusFields()
        {
            Countries = new HashSet<Countries>();
            Departments = new HashSet<Departments>();
            JobPositions = new HashSet<JobPositions>();
            RequestCategories = new HashSet<RequestCategories>();
            Rosters = new HashSet<Rosters>();
            Site = new HashSet<Site>();
            Skills = new HashSet<Skills>();
            StatusEmployees = new HashSet<StatusEmployees>();
            StatusRequest = new HashSet<StatusRequest>();
            TypeRequests = new HashSet<TypeRequests>();
        }

        public int StatusFieldId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<JobPositions> JobPositions { get; set; }
        public virtual ICollection<RequestCategories> RequestCategories { get; set; }
        public virtual ICollection<Rosters> Rosters { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<StatusEmployees> StatusEmployees { get; set; }
        public virtual ICollection<StatusRequest> StatusRequest { get; set; }
        public virtual ICollection<TypeRequests> TypeRequests { get; set; }
    }
}
