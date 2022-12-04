using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class AccountRecoveryMV
    {
        [Required(ErrorMessage = "UserName is Required*")]
        public string UserName { get; set; }
    }
}