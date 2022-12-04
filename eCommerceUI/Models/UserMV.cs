using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace eCommerceUI.Models
{
    public class UserMV
    {
        public UserMV()
        {
            GenderList = new List<GenderMV>();
            foreach (var gender in new DatabaseLayer.Pro_EccomerceDbEntities().GenderTables.ToList())
            {
                GenderList.Add(new GenderMV() { GenderID = gender.GenderID, GenderTitle = gender.GenderTitle });
            }
            UserTypeList = new List<UserTypeMV>();
            foreach (var usertype in new DatabaseLayer.Pro_EccomerceDbEntities().UserTypeTables.ToList())
            {
                UserTypeList.Add(new UserTypeMV() { UserTypeID = usertype.UserTypeID, UserType = usertype.UserType });
            }
        }
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public string UserType { get; set; }

        [Required(ErrorMessage = "Enter User Name*")]
        [Remote("IsAlreadyUserRegistered", "User", HttpMethod = "POST", ErrorMessage = "UserName Already Exist!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Confirm Your Password*")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Confirm Password Not Match.")]
        public string ConfirmPassword { get; set; }
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Email Address*")]
        [Remote("IsEmailAlreadyRegistered", "User", HttpMethod = "POST", ErrorMessage = "Email Already Exist!")]
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression("(^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$)", ErrorMessage = "Only Number's Allowed.")]
        [Required(ErrorMessage = "Enter Contact No*")]
        [Remote("IsContactNoAlreadyRegistered", "User", HttpMethod = "POST", ErrorMessage = "Contact No Already Exist!")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Select Gender*")]
        public int GenderID { get; set; }
        public string Gender { get; set; }
        public int UserStatusID { get; set; }
        public string UserStatus { get; set; }
        public virtual List<GenderMV> GenderList { get; set; }
        public virtual List<UserTypeMV> UserTypeList { get; set; }
    }
}