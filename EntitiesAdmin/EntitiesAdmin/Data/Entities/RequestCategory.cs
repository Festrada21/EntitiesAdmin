using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiesAdmin.Data.Entities
{
    public partial class RequestCategory
    {
        public RequestCategory()
        {
            TypeRequests = new HashSet<TypeRequest>();
        }
        #region Data

        public int RequestCategoryId { get; set; }

        [Display(Name = "Request Category")]
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
        #region Relations

        public virtual StatusField StatusField { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TypeRequest> TypeRequests { get; set; } 
        #endregion
    }
}
