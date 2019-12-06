﻿using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class StatusEmployee
    {
        public StatusEmployee()
        {
            Employees = new HashSet<Employee>();
        }

        public int StatusEmployeeId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime? EditionDate { get; set; }

        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}