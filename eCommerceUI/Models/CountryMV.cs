using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class CountryMV
    {
        public int CountryID { get; set; }
        [Display(Name = "Contry")]
        [Required(ErrorMessage = "Required*")]
        public string CountryTitle { get; set; }

    }
}