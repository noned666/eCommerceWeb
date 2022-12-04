using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class CityMV
    {
        public int CityID { get; set; }
        public int CountryID { get; set; }
        [Display(Name = "City Name")]
        [Required(ErrorMessage = "Required*")]
        public string CityName { get; set; }
        public string CountryName { get; internal set; }
    }
}