using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiesAdmin.Data.Entities
{
    public partial class StatusEmployee
    {
        public StatusEmployee()
        {
            Employees = new HashSet<Employee>();
        }

        public int StatusEmployeeId { get; set; }

        [Display(Name = "Status Employee")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
        public int? StatusFieldId { get; set; }
        public string UserId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EditionDate { get; set; }

        [Display(Name = "Edition Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime EditionDateLocal => EditionDate.ToLocalTime();
        
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
