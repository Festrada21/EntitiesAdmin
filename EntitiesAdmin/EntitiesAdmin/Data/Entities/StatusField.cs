using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class StatusField
    {
        public StatusField()
        {
            Countries = new HashSet<Country>();
            Departments = new HashSet<Department>();
            JobPositions = new HashSet<JobPosition>();
            RequestCategories = new HashSet<RequestCategory>();
            Rosters = new HashSet<Roster>();
            Site = new HashSet<Site>();
            Skills = new HashSet<Skill>();
            StatusEmployees = new HashSet<StatusEmployee>();
            StatusRequest = new HashSet<StatusRequest>();
            TypeRequests = new HashSet<TypeRequest>();
        }

        #region Data
        public int StatusFieldId { get; set; }
        public string Name { get; set; } 
        #endregion

        #region Relations
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<JobPosition> JobPositions { get; set; }
        public virtual ICollection<RequestCategory> RequestCategories { get; set; }
        public virtual ICollection<Roster> Rosters { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<StatusEmployee> StatusEmployees { get; set; }
        public virtual ICollection<StatusRequest> StatusRequest { get; set; }
        public virtual ICollection<TypeRequest> TypeRequests { get; set; } 
        #endregion
    }
}
