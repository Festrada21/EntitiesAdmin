using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class StatusRequest
    {       
        public int StatusRequestId { get; set; }
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }
        public DateTime EditionDate { get; set; }
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
