using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class GenderMV
    {
        public int GenderID { get; set; }
        [Display(Name = "Gender table")]
        [Required(ErrorMessage = "Required*")]
        public string GenderTitle { get; set; }

    }
}