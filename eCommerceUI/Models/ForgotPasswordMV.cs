using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class ForgotPasswordMV
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Enter UserName")]
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Enter New Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}