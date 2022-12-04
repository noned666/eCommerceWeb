using DatabaseLayer;
using eCommerceUI.Models;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;



namespace eCommerceUI.Controllers
{
    public class PasswordRecoveryController : Controller
    {
        // GET: PasswordRecovery
        private Pro_EccomerceDbEntities DB = new Pro_EccomerceDbEntities();
        // GET: PasswordRecovery
        public ActionResult AccountRecovery()
        {

            var accountRecoveryMV = new AccountRecoveryMV();
            return View(accountRecoveryMV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountRecovery(AccountRecoveryMV accountRecoveryMV)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var user = DB.UserTables.Where(u => u.UserName.Trim() == accountRecoveryMV.UserName || u.EmailAddress == accountRecoveryMV.UserName.Trim()).FirstOrDefault();
                        if (user != null)
                        {
                            string code = DateTime.Now.ToString("yyyyMMddHHmmssmm") + accountRecoveryMV.UserName;
                            var accountrecoverydetails = new PasswordRecoveryTable();
                            accountrecoverydetails.UserID = user.UserID;
                            accountrecoverydetails.OldPassword = user.Password;
                            accountrecoverydetails.RecoveryCode = code;
                            accountrecoverydetails.RecoveryCodeExpiryDateTime = DateTime.Now.AddDays(1);
                            accountrecoverydetails.RecoveryStatus = true;
                            DB.PasswordRecoveryTables.Add(accountrecoverydetails);
                            DB.SaveChanges();

                            var callbackUrl = Url.Action("ResetPassword", "User", new { recoverycode = code }, protocol: Request.Url.Scheme);
                            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                            string body = string.Empty;
                            using (StreamReader reader = new StreamReader(Server.MapPath("~/MailTemplates/ForgotPasswordConfirmation.html")))
                            {
                                body = reader.ReadToEnd();
                            }
                            body = body.Replace("{ConfirmationLink}", callbackUrl);
                            body = body.Replace("{UserName}", user.EmailAddress);
                            bool IsSendEmail = CommonCode.Send.EmailSend(user.EmailAddress, "Reset Password", body, true);
                            if (IsSendEmail)
                            {
                                transaction.Commit();
                                ModelState.AddModelError(string.Empty, "Recovery Link Sent on your email address(" + user.EmailAddress + ")");
                            }
                            else
                            {
                                transaction.Rollback();
                                ModelState.AddModelError(string.Empty, "Some Issue is Occure! Please Try Again later.");
                            }
                        }
                        else
                        {
                            transaction.Rollback();
                            ModelState.AddModelError("UserName", "Not Found!");
                        }
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError(string.Empty, "Some Issue is Occure! Please Try Again later.");
                }
            }
            return View(accountRecoveryMV);
        }

        public ActionResult ResetPassword(string recoverycode)
        {

            var forgotpassword = new ForgotPasswordMV();
            var userrecovery = DB.PasswordRecoveryTables.Where(p => p.RecoveryCode == recoverycode && p.RecoveryCodeExpiryDateTime > DateTime.Now && p.RecoveryStatus == true).FirstOrDefault();
            if (userrecovery == null)
            {
                return RedirectToAction("Login");
            }
            var user = DB.UserTables.Find(userrecovery.UserID);
            forgotpassword.UserID = userrecovery.UserID;
            forgotpassword.UserName = user.UserName;
            forgotpassword.EmailAddress = user.EmailAddress;
            return View(forgotpassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ForgotPasswordMV forgotPasswordMV)
        {
            using (var transaction = DB.Database.BeginTransaction())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var user = DB.UserTables.Find(forgotPasswordMV.UserID);
                        if (user != null)
                        {
                            if (forgotPasswordMV.NewPassword != forgotPasswordMV.ConfirmPassword)
                            {
                                ModelState.AddModelError("ConfirmPassword", "Not Match!");
                                return View(forgotPasswordMV);
                            }

                            var userrecovery = DB.PasswordRecoveryTables.Where(u => u.UserID == forgotPasswordMV.UserID && u.RecoveryStatus == true);
                            foreach (var item in userrecovery)
                            {
                                item.RecoveryStatus = false;
                                item.OldPassword = user.Password;
                                DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
                                DB.SaveChanges();
                            }
                            user.Password = forgotPasswordMV.NewPassword;
                            DB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();
                            transaction.Commit();
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Please Try-Again!");
                            return View(forgotPasswordMV);
                        }
                    }
                    ModelState.AddModelError(string.Empty, "Fill Field's Properly!");
                }
                catch
                {
                    ModelState.AddModelError(string.Empty, "Please Try Again later.");
                }
            }
            return View(forgotPasswordMV);
        }






    }
}