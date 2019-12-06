using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            User = new HashSet<User>();
        }

        #region Data
        public int EmployeeId { get; set; }

        [MaxLength(25, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string EmployeeCode { get; set; }
        [Display(Name = "First Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string MiddleName { get; set; }

        [Display(Name = "First Surname")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string FirstSurname { get; set; }

        [Display(Name = "Second Surname")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is required.")]
        public string SecondSurname { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime? HireDateLocal
        {
            get
            {
                if (this.HireDate == null)
                {
                    return null;
                }

                return this.HireDate.ToLocalTime();
            }
        }

        [Display(Name = "Low Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime LowDate { get; set; }

        [Display(Name = "Low Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime? LowDateLocal
        {
            get
            {
                if (this.LowDate == DateTime.Parse("0001/01/01"))
                {
                    return null;
                }

                return this.LowDate.ToLocalTime();
            }
        }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "JobPosition")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a job position.")]
        public int JobPositionId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Country")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a country.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Site")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a site.")]
        public int SiteId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Status")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a status.")]
        public int? StatusEmployeeId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Skill")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a skill.")]
        public int SkillId { get; set; }

        [Display(Name = "Photo")]
        public string ImageUrl { get; set; }
        #endregion

        #region NotMapped
        [NotMapped]
        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Department")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a department.")]
        public int DepartmentId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Departments { get; set; }
        
        [NotMapped]
        public IEnumerable<SelectListItem> Skills { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> JobPositions { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Countries { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Sites { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> StatusEmployees { get; set; }

        [NotMapped]
        [Display(Name = "Photo")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {MiddleName} {FirstSurname} {SecondSurname}";

        //TODO: replace the correct URL for the image
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
           ? null
           : $"http://www.festrada.somee.com{ImageUrl.Substring(1)}";
        #endregion

        #region Relations

        public virtual Country Country { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        public virtual Site Site { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual StatusEmployee StatusEmployee { get; set; }
        public virtual ICollection<User> User { get; set; } 
        #endregion
    }
}
