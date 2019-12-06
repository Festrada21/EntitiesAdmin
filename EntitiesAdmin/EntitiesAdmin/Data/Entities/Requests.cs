using System;
using System.Collections.Generic;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Requests
    {
        public int RequestId { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public int TypeRequestId { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public int StatusRequestId { get; set; }

        public virtual StatusRequest StatusRequest { get; set; }
        public virtual TypeRequests TypeRequest { get; set; }
        public virtual User User { get; set; }
    }
}
