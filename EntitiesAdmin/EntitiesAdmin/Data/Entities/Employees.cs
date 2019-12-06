using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Employees
    {
        public Employees()
        {
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime LowDate { get; set; }
        public int? JobPositionId { get; set; }
        public int? CountryId { get; set; }
        public int? SiteId { get; set; }
        public int? StatusEmployeeId { get; set; }
        public int? SkillId { get; set; }
        public string ImageUrl { get; set; }

        public virtual Countries Country { get; set; }
        public virtual JobPositions JobPosition { get; set; }
        public virtual Site Site { get; set; }
        public virtual Skills Skill { get; set; }
        public virtual StatusEmployees StatusEmployee { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}
