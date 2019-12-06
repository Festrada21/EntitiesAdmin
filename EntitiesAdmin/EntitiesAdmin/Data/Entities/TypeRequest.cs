using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesAdmin.Data.Entities
{
    public partial class TypeRequest
    {
        public TypeRequest()
        {
            Requests = new HashSet<Request>();
        }
        #region Data

        public int TypeRequestId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Department")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a department.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "Request Category")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a request category.")]
        public int RequestCategoryId { get; set; }
        public string Name { get; set; }

        public int StatusFieldId { get; set; }

        public string UserId { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EditionDate { get; set; }
        #endregion

        #region NoMapped
        [NotMapped]
        public IEnumerable<SelectListItem> Departments { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RequestCategories { get; set; }

        #endregion


        #region Relations
        public virtual Department Department { get; set; }
        public virtual RequestCategory RequestCategory { get; set; }
        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        #endregion
    }
}
