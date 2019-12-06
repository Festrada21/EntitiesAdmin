using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Skills = new HashSet<Skill>();
            TypeRequests = new HashSet<TypeRequest>();
        }

        #region Data
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Roster")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a roster.")]
        public int RosterId { get; set; }

        [Display(Name = "Department")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
        public int StatusFieldId { get; set; }
        public string UserId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EditionDate { get; set; }

        [Display(Name = "Edition Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime EditionDateLocal => EditionDate.ToLocalTime();
        #endregion

        #region relations
        public virtual Roster Roster { get; set; }
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<TypeRequest> TypeRequests { get; set; } 
        #endregion
    }
}
