using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DatabaseLayer;
using eCommerceUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace eCommerceUI.Controllers
{
    public class UserController : Controller
    {
        Pro_EccomerceDbEntities DB = new Pro_EccomerceDbEntities();
        public ActionResult User_List()
        {
            var list = new List<UserMV>();
            foreach (var user in DB.UserTables.ToList())
            {
                list.Add(new UserMV()
                {
                    UserID = user.UserID,
                    UserType = user.UserTypeTable.UserType,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ContactNo = user.ContactNo,
                    Gender = user.GenderTable.GenderTitle,
                    UserStatus = user.UserStatusTable.UserStatuc,
                });
            }
            return View(list);
        }
        public ActionResult Register()
        {
            return View(new UserMV());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserMV userMV)
        {
            if (ModelState.IsValid)
            {
                float contactno = 0;
                float.TryParse(userMV.ContactNo.Trim(), out contactno);
                if (contactno > 0)
                {
                    var user = new UserTable();

                    user.UserTypeID = 2;
                    user.UserName = userMV.UserName;
                    user.Password = userMV.Password;
                    user.EmailAddress = userMV.EmailAddress;
                    user.FirstName = userMV.FirstName;
                    user.LastName = userMV.LastName;
                    user.ContactNo = userMV.ContactNo;
                    user.GenderID = userMV.GenderID;
                    user.UserStatusID = 2;
                    DB.UserTables.Add(user);
                    DB.SaveChanges();
                    return RedirectToAction("User_List");
                }
                else
                {
                    ModelState.AddModelError("ContactNo", "Incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Fill All Field's Properly!");
            }
            return View(userMV);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRegister_Partial(UserMV userMV)
        {
            if (ModelState.IsValid)
            {
                float contactno = 0;
                float.TryParse(userMV.ContactNo.Trim(), out contactno);
                if (contactno > 0)
                {
                    var user = new UserTable();

                    user.UserTypeID = 2;
                    user.UserName = userMV.UserName;
                    user.Password = userMV.Password;
                    user.EmailAddress = userMV.EmailAddress;
                    user.FirstName = userMV.FirstName;
                    user.LastName = userMV.LastName;
                    user.ContactNo = userMV.ContactNo;
                    user.GenderID = userMV.GenderID;
                    user.UserStatusID = 2;
                    DB.UserTables.Add(user);
                    DB.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ContactNo", "Incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Fill All Field's Properly!");
            }
            return PartialView(new UserMV());
        }
        public JsonResult Login_Partial(string username, string password)
        {
            string message = string.Empty;
            var user = DB.UserTables.Where(u => (u.UserName == username.Trim() || u.EmailAddress == username.Trim()) && u.Password == password.Trim()).FirstOrDefault();
            if (user != null)
            {
                if (user.UserStatusID == 1)
                {
                    message = "Your Account Pending";
                }
                else if (user.UserStatusID == 2)
                {
                    message = "/Home/Index";
                }
                else if (user.UserStatusID == 3)
                {
                    message = "Your Account Rejected";
                }
                else if (user.UserStatusID == 4)
                {
                    message = "Your Account Suspended";
                }
                else if (user.UserStatusID == 5)
                {
                    message = "Your Account Processing";
                }
            }
            else
            {
                message = "Incorrect User Credentials";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult IsAlreadyUserRegistered(string UserName)
        {
            bool status;

            var user = (from u in DB.UserTables
                        where u.UserName.ToUpper() == UserName.ToUpper()
                        select new { UserName }).FirstOrDefault();
            if (user != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }
            return Json(status);
        }
        [HttpPost]
        public JsonResult IsEmailAlreadyRegistered(string EmailAddress)
        {
            bool status;

            var user = (from u in DB.UserTables
                        where u.EmailAddress.ToUpper() == EmailAddress.ToUpper()
                        select new { EmailAddress }).FirstOrDefault();
            if (user != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }
            return Json(status);
        }
        [HttpPost]
        public JsonResult IsContactNoAlreadyRegistered(string ContactNo)
        {
            bool status;

            var user = (from u in DB.UserTables
                        where u.ContactNo.ToUpper() == ContactNo.ToUpper()
                        select new { ContactNo }).FirstOrDefault();
            if (user != null)
            {
                //Already registered  
                status = false;
            }
            else
            {
                //Available to use  
                status = true;
            }
            return Json(status);
        }

        public ActionResult UserAddress()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "User");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);
            return View(new Reg_UserAddressMV(userid));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAddress(Reg_UserAddressMV reg_UserAddressMV)
        {
            if (ModelState.IsValid)
            {
                var useraddress = new UserAddressTable();
                useraddress.UserID = reg_UserAddressMV.UserID;
                useraddress.AddressTypeID = reg_UserAddressMV.AddressTypeID;
                useraddress.FullAddress = reg_UserAddressMV.FullAddress;
                useraddress.CityID = reg_UserAddressMV.CityID;
                useraddress.PostalCode = reg_UserAddressMV.PostalCode;
                useraddress.ContactNo = reg_UserAddressMV.ContactNo;
                useraddress.StatusID = reg_UserAddressMV.StatusID;
                DB.UserAddressTables.Add(useraddress);
                DB.SaveChanges();
                return RedirectToAction("UserAddress");
            }
            return View(reg_UserAddressMV);
        }

        public ActionResult EditUserAddress(int? id)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Session["UserID"])))
            {
                return RedirectToAction("Login", "User");
            }
            int userid = 0;
            int.TryParse(Convert.ToString(Session["UserID"]), out userid);

            var address = DB.UserAddressTables.Find(id);
            var edituseraddress = new Reg_UserAddressMV(userid);

            edituseraddress.UserAddressID = address.UserAddressID;
            edituseraddress.UserID = address.UserID;
            edituseraddress.AddressTypeID = address.AddressTypeID;
            edituseraddress.FullAddress = address.FullAddress;
            edituseraddress.CityID = address.CityID;
            edituseraddress.PostalCode = address.PostalCode;
            edituseraddress.ContactNo = address.ContactNo;
            edituseraddress.StatusID = address.StatusID;
            return View(edituseraddress);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAddress(Reg_UserAddressMV reg_UserAddressMV)
        {
            if (ModelState.IsValid)
            {
                var useraddress = DB.UserAddressTables.Find(reg_UserAddressMV.UserAddressID);
                useraddress.AddressTypeID = reg_UserAddressMV.AddressTypeID;
                useraddress.FullAddress = reg_UserAddressMV.FullAddress;
                useraddress.CityID = reg_UserAddressMV.CityID;
                useraddress.PostalCode = reg_UserAddressMV.PostalCode;
                useraddress.ContactNo = reg_UserAddressMV.ContactNo;
                useraddress.StatusID = reg_UserAddressMV.StatusID;
                DB.Entry(useraddress).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("UserAddress");
            }
            return View(reg_UserAddressMV);
        }


        public ActionResult CustomerRegister()
        {
            return View(new UserMV());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerRegister(UserMV userMV)
        {
            if (ModelState.IsValid)
            {
                float contactno = 0;
                float.TryParse(userMV.ContactNo.Trim(), out contactno);
                if (contactno > 0)
                {
                    var user = new UserTable();
                    user.UserTypeID = 2;
                    user.UserName = userMV.UserName;
                    user.Password = userMV.Password;
                    user.EmailAddress = userMV.EmailAddress;
                    user.FirstName = userMV.FirstName;
                    user.LastName = userMV.LastName;
                    user.ContactNo = userMV.ContactNo;
                    user.GenderID = userMV.GenderID;
                    user.UserStatusID = 2;
                    DB.UserTables.Add(user);
                    DB.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("ContactNo", "Incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Fill All Field's Properly!");
            }
            return View(userMV);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            string message = string.Empty;
            var user = DB.UserTables.Where(u => (u.UserName == username.Trim() || u.EmailAddress == username.Trim()) && u.Password == password.Trim()).FirstOrDefault();
            if (user != null)
            {
                if (user.UserStatusID == 1)
                {
                    ModelState.AddModelError("", "Your Account Pending");
                }
                else if (user.UserStatusID == 2)
                {
                    Session["UserID"] = user.UserID;
                    return RedirectToAction("Index", "Home");
                }
                else if (user.UserStatusID == 3)
                {
                    ModelState.AddModelError("", "Your Account Rejected");
                }
                else if (user.UserStatusID == 4)
                {
                    ModelState.AddModelError("", "Your Account Suspended");
                }
                else if (user.UserStatusID == 5)
                {
                    ModelState.AddModelError("", "Your Account Processing");
                }
            }
            else
            {
                ModelState.AddModelError("", "Incorrect User Credentials");
            }
            return View();
        }

    }
}