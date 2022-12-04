using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class UserStatusMV
    {
        public int UserStatusID { get; set; }
        [Display(Name="UserStatus Type")]
        [Required(ErrorMessage ="Required*")]
        public string UserStatuc { get; set; }
    }
}