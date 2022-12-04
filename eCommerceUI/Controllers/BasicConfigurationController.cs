using DatabaseLayer;
using eCommerceUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
namespace eCommerceUI.Controllers
{
    public class BasicConfigurationController : Controller
    {
        //Список моделей ролей пользователя
        Pro_EccomerceDbEntities db = new Pro_EccomerceDbEntities();
        public ActionResult UserTypes_List()
        {
            var list = new List<UserTypeMV>();
            foreach (var usertype in db.UserTypeTables.ToList())
            {
                list.Add(new UserTypeMV() { 
                UserTypeID = usertype.UserTypeID,
                    UserType = usertype.UserType
                });
            }
            return View(list);
        }

        //Создание новой модели роли пользователя
        public ActionResult NewUserType()
        {
            return View(new UserTypeMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUserType(UserTypeMV userTypeMV)
        {
            if (ModelState.IsValid)
            {
                var usertype = new UserTypeTable();
                usertype.UserType = userTypeMV.UserType;
                db.UserTypeTables.Add(usertype);
                db.SaveChanges();
                return RedirectToAction("UserTypes_List");
            }
            ModelState.AddModelError("UserType", "User Type is Required");
            return View(userTypeMV);
        }
        //Изменение модели роли пользователя
        public ActionResult EditUserType(int? id)
        {
            var getusertype = db.UserTypeTables.Find(id);
            var editusertype = new UserTypeMV();
            editusertype.UserType = getusertype.UserType;
            editusertype.UserTypeID = getusertype.UserTypeID;

            return View(editusertype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserType(UserTypeMV userTypeMV)
        {
            var check_exist = db.UserTypeTables.Where(u => u.UserType == userTypeMV.UserType.Trim() && u.UserTypeID != userTypeMV.UserTypeID).FirstOrDefault();
            if (check_exist == null)
            {
                var obj = db.UserTypeTables.Find(userTypeMV.UserTypeID);
                obj.UserType = userTypeMV.UserType;
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserTypes_List");

            }
           
            ModelState.AddModelError("UserType", "User Type is Required Field.");
            return View(userTypeMV);
        }
        //страница с типами адрессов
        public ActionResult AddressTypes_List()
        {
            var list = new List<AddressTypeMV>();
            foreach (var addresstype in db.AddressTypeTables.ToList())
            {
                list.Add(new AddressTypeMV()
                {
                    AddressTypeID = addresstype.AddressTypeID,
                    AddressType = addresstype.AddressType
                });
            }
            return View(list);
        }
        //Страница с созданием типов адрессов
        public ActionResult NewAddressType()
        {
            return View(new AddressTypeMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewAddressType(AddressTypeMV addressTypeMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.AddressTypeTables.Where(a => a.AddressType == addressTypeMV.AddressType.Trim()).FirstOrDefault();
                if (check_exist == null)
                {
                    var addresstype = new AddressTypeTable();
                    addresstype.AddressType = addressTypeMV.AddressType;
                    db.AddressTypeTables.Add(addresstype);
                    db.SaveChanges();
                    return RedirectToAction("AddressTypes_List");
                }
                else
                {
                    ModelState.AddModelError("AddressType", "Address Type Already Registered.");
                }
            }
            ModelState.AddModelError("AddressType", "Address Type is Required");
            return View(addressTypeMV);
        }
        //Редактирование типов адрессов
        public ActionResult EditAddressType(int? id)
        {
            var addresstype = db.AddressTypeTables.Find(id);
            var editaddresstype = new AddressTypeMV();
            editaddresstype.AddressTypeID = addresstype.AddressTypeID;
            editaddresstype.AddressType = addresstype.AddressType;
            return View(editaddresstype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAddressType(AddressTypeMV addressTypeMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.AddressTypeTables.Where(a => a.AddressType == addressTypeMV.AddressType.Trim() && a.AddressTypeID != addressTypeMV.AddressTypeID).FirstOrDefault();
                if (check_exist == null)
                {
                    var addresstype = db.AddressTypeTables.Find(addressTypeMV.AddressTypeID);
                    addresstype.AddressType = addressTypeMV.AddressType;
                    db.Entry(addresstype).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("AddressTypes_List");
                }
                else
                {
                    ModelState.AddModelError("AddressType", "Address Type Already Registered.");
                }
            }
            ModelState.AddModelError("AddressType", "Address Type is Required");
            return View(addressTypeMV);
        }
        //Страница со статусом пользователя
        public ActionResult UserStatus_List()
        {
            var list = new List<UserStatusMV>();
            foreach (var userstatus in db.UserStatusTables.ToList())
            {
                list.Add(new UserStatusMV()
                {
                    UserStatuc = userstatus.UserStatuc,
                    UserStatusID = userstatus.UserStatusID
                });
            }
            return View(list);
        }
        //Страница с созданием статусоа пользователя
        public ActionResult NewUserStatus()
        {
            return View(new UserStatusMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewUserStatus(UserStatusMV userStatusMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.UserStatusTables.Where(a => a.UserStatuc == userStatusMV.UserStatuc.Trim()).FirstOrDefault();
                if (check_exist == null)
                {
                    var userstatus = new UserStatusTable();
                    userstatus.UserStatuc = userStatusMV.UserStatuc;
                    db.UserStatusTables.Add(userstatus);
                    db.SaveChanges();
                    return RedirectToAction("UserStatus_List");
                }
                else
                {
                    ModelState.AddModelError("UserStatus", "User Status Already Registered.");
                }
            }
            ModelState.AddModelError("UserStatus", "User Status is Required");
            return View(userStatusMV);
        }

        //Редактирование статуса пользователя
        public ActionResult EditUserStatus(int? id)
        {
            var userstatus = db.UserStatusTables.Find(id);
            var edituserstatus = new UserStatusMV();
            edituserstatus.UserStatusID = userstatus.UserStatusID;
            edituserstatus.UserStatuc = userstatus.UserStatuc;
            return View(edituserstatus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserStatus(UserStatusMV userStatusMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.UserStatusTables.Where(a => a.UserStatuc == userStatusMV.UserStatuc.Trim() && a.UserStatusID != userStatusMV.UserStatusID).FirstOrDefault();
                if (check_exist == null)
                {
                    var userstatus = db.UserStatusTables.Find(userStatusMV.UserStatusID);
                    userstatus.UserStatuc = userStatusMV.UserStatuc;
                    db.Entry(userstatus).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("UserStatus_List");
                }
                else
                {
                    ModelState.AddModelError("UserStatus", "User Status Already Registered.");
                }
            }
            ModelState.AddModelError("UserStatus", "User Status is Required");
            return View(userStatusMV);
        }

        public ActionResult Gender_List()
        {
            var list = new List<GenderMV>();
            foreach (var gender in db.GenderTables.ToList())
            {
                list.Add(new GenderMV()
                {
                    GenderTitle = gender.GenderTitle,
                    GenderID = gender.GenderID
                });
            }
            return View(list);
        }

        public ActionResult NewGender()
        {
            return View(new GenderMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewGender(GenderMV genderMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.GenderTables.Where(a => a.GenderTitle == genderMV.GenderTitle.Trim()).FirstOrDefault();
                if (check_exist == null)
                {
                    var gender = new GenderTable();
                    gender.GenderTitle = genderMV.GenderTitle;
                    db.GenderTables.Add(gender);
                    db.SaveChanges();
                    return RedirectToAction("Gender_List");
                }
                else
                {
                    ModelState.AddModelError("GenderTitle", "Already Registered.");
                }
            }
            ModelState.AddModelError("GenderTitle", "Required Field");
            return View(genderMV);
        }

        public ActionResult EditGender(int? id)
        {
            var gender = db.GenderTables.Find(id);
            var editgender = new GenderMV();
            editgender.GenderID = gender.GenderID;
            editgender.GenderTitle = gender.GenderTitle;
            return View(editgender);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditGender(GenderMV genderMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.GenderTables.Where(a => a.GenderTitle == genderMV.GenderTitle.Trim() && a.GenderID != genderMV.GenderID).FirstOrDefault();
                if (check_exist == null)
                {
                    var gender = db.GenderTables.Find(genderMV.GenderID);
                    gender.GenderTitle = genderMV.GenderTitle;
                    db.Entry(gender).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Gender_List");
                }
                else
                {
                    ModelState.AddModelError("GenderTitle", "Already Registered.");
                }
            }
            ModelState.AddModelError("GenderTitle", "Required Field");
            return View(genderMV);
        }

        public ActionResult Countries_List()
        {
            var list = new List<CountryMV>();
            foreach (var country in db.CountryTables.ToList())
            {
                list.Add(new CountryMV()
                {
                    CountryID = country.CountryID,
                    CountryTitle = country.CountryTitle
                });
            }
            return View(list);
        }

        public ActionResult NewCountry()
        {
            return View(new CountryMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCountry(CountryMV countryMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.CountryTables.Where(a => a.CountryTitle == countryMV.CountryTitle.Trim()).FirstOrDefault();
                if (check_exist == null)
                {
                    var country = new CountryTable();
                    country.CountryTitle = countryMV.CountryTitle;
                    db.CountryTables.Add(country);
                    db.SaveChanges();
                    return RedirectToAction("Countries_List");
                }
                else
                {
                    ModelState.AddModelError("CountryTitle", "Already Registered.");
                }
            }
            ModelState.AddModelError("CountryTitle", "Required Field");
            return View(countryMV);
        }

        public ActionResult EditCountry(int? id)
        {
            var getcountry = db.CountryTables.Find(id);
            var editcountry = new CountryMV();
            editcountry.CountryID = getcountry.CountryID;
            editcountry.CountryTitle = getcountry.CountryTitle;
            return View(editcountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCountry(CountryMV countryMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.CountryTables.Where(a => a.CountryTitle == countryMV.CountryTitle.Trim() && a.CountryID != countryMV.CountryID).FirstOrDefault();
                if (check_exist == null)
                {
                    var country = db.CountryTables.Find(countryMV.CountryID);
                    country.CountryTitle = countryMV.CountryTitle;
                    db.Entry(country).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Countries_List");
                }
                else
                {
                    ModelState.AddModelError("CountryTitle", "Already Registered.");
                }
            }
            ModelState.AddModelError("CountryTitle", "Required Field");
            return View(countryMV);
        }

        public ActionResult Cities_List()
        {
            var list = new List<CityMV>();
            foreach (var city in db.CityTables.ToList())
            {
                var country = db.CountryTables.Find(city.CountryID);
                list.Add(new CityMV()
                {
                    CountryID = city.CountryID,
                    CityID = city.CityID,
                    CityName = city.CityName,
                    CountryName = country.CountryTitle
                });
            }
            return View(list);
        }

        public ActionResult NewCity()
        {
            ViewBag.CountryID = new SelectList(db.CountryTables.ToList(), "CountryID", "CountryTitle", "0");
            return View(new CityMV());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCity(CityMV cityMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.CityTables.Where(a => a.CityName == cityMV.CityName.Trim() && a.CountryID == cityMV.CountryID).FirstOrDefault();
                if (check_exist == null)
                {
                    var city = new CityTable();
                    city.CityName = cityMV.CityName;
                    city.CountryID = cityMV.CountryID;
                    db.CityTables.Add(city);
                    db.SaveChanges();
                    return RedirectToAction("Cities_List");
                }
                else
                {
                    ModelState.AddModelError("CityName", "Already Registered.");
                }
            }
            ModelState.AddModelError("CityName", "Required Field");
            ViewBag.CountryID = new SelectList(db.CountryTables.ToList(), "CountryID", "CountryTitle", cityMV.CountryID);
            return View(cityMV);
        }

        public ActionResult EditCity(int? id)
        {
            var getcity = db.CityTables.Find(id);
            var editcity = new CityMV();
            editcity.CountryID = getcity.CountryID;
            editcity.CityID = getcity.CityID;
            editcity.CityName = getcity.CityName;
            ViewBag.CountryID = new SelectList(db.CountryTables.ToList(), "CountryID", "CountryTitle", editcity.CountryID);
            return View(editcity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCity(CityMV cityMV)
        {
            if (ModelState.IsValid)
            {
                var check_exist = db.CityTables.Where(a => a.CityName == cityMV.CityName.Trim() && a.CityID != cityMV.CityID && a.CountryID == cityMV.CountryID).FirstOrDefault();
                if (check_exist == null)
                {
                    var city = db.CityTables.Find(cityMV.CityID);
                    city.CityName = cityMV.CityName;
                    city.CountryID = cityMV.CountryID;
                    db.Entry(city).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Cities_List");
                }
                else
                {
                    ModelState.AddModelError("CityName", "Already Registered.");
                }
            }
            ModelState.AddModelError("CityName", "Required Field");
            ViewBag.CountryID = new SelectList(db.CountryTables.ToList(), "CountryID", "CountryTitle", cityMV.CountryID);
            return View(cityMV);
        }

        // Get Cities By Country ID
        public JsonResult GetCitiesByCountryID(int? countryid)
        {
            var Cities = new List<CityMV>();
            var cities = new DatabaseLayer.Pro_EccomerceDbEntities().CityTables.Where(c => c.CountryID == countryid).ToList();
            foreach (var city in cities)
            {
                string countrytitle = city.CountryTable.CountryTitle;
                Cities.Add(new CityMV { CityID = city.CityID, CityName = city.CityName, CountryID = city.CountryID, CountryName = countrytitle });
            }
            return Json(Cities, JsonRequestBehavior.AllowGet);
        }


    }

}