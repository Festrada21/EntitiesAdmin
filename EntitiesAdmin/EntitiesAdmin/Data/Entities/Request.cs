using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntitiesAdmin.Data.Entities
{
    public partial class Request
    {
        #region Data
        public int RequestId { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd H:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Edition Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime DateLocal => Date.ToLocalTime();

        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        [Display(Name = "TypeReques")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a TypeReques.")]
        public int TypeRequestId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public string Remarks { get; set; }

        public string UserId { get; set; }

        public int StatusRequestId { get; set; }

        #endregion
        #region Relations
        public virtual StatusRequest StatusRequest { get; set; }
        public virtual TypeRequest TypeRequest { get; set; }
        public virtual User User { get; set; } 
        #endregion
    }
}
