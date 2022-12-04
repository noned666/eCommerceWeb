using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class AddressTypeMV
    {
        public int AddressTypeID { get; set; }
        [Display(Name="Address Type")]
        [Required(ErrorMessage ="Required*")]
        public string AddressType { get; set; }
    }
}