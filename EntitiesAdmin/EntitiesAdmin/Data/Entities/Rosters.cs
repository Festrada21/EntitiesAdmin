﻿using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Rosters
    {
        public Rosters()
        {
            Departments = new HashSet<Departments>();
        }

        public int RosterId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime EditionDate { get; set; }

        public virtual StatusFields StatusField { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Departments> Departments { get; set; }
    }
}
