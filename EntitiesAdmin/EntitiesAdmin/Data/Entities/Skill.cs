using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            Employees = new HashSet<Employee>();
        }
        #region Data

        public int SkillId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Department")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a department.")]
        public int DepartmentId { get; set; }

        [Display(Name = "Skill")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string Name { get; set; }
        public int StatusFieldId { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EditionDate { get; set; }

        [Display(Name = "Edition Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime EditionDateLocal => EditionDate.ToLocalTime();

        #region NotMapped
        [NotMapped]
        public IEnumerable<SelectListItem> Departments { get; set; } 
        #endregion

        #endregion
        #region relations
        public virtual Department Department { get; set; }
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } 
        #endregion
    }
}
