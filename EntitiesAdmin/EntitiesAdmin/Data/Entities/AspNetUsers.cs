using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Countries = new HashSet<Countries>();
            Departments = new HashSet<Departments>();
            JobPositions = new HashSet<JobPositions>();
            RequestCategories = new HashSet<RequestCategories>();
            Requests = new HashSet<Requests>();
            Rosters = new HashSet<Rosters>();
            Site = new HashSet<Site>();
            Skills = new HashSet<Skills>();
            StatusEmployees = new HashSet<StatusEmployees>();
            StatusRequest = new HashSet<StatusRequest>();
            TypeRequests = new HashSet<TypeRequests>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Countries> Countries { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
        public virtual ICollection<JobPositions> JobPositions { get; set; }
        public virtual ICollection<RequestCategories> RequestCategories { get; set; }
        public virtual ICollection<Requests> Requests { get; set; }
        public virtual ICollection<Rosters> Rosters { get; set; }
        public virtual ICollection<Site> Site { get; set; }
        public virtual ICollection<Skills> Skills { get; set; }
        public virtual ICollection<StatusEmployees> StatusEmployees { get; set; }
        public virtual ICollection<StatusRequest> StatusRequest { get; set; }
        public virtual ICollection<TypeRequests> TypeRequests { get; set; }
    }
}
