using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class Reg_UserAddressMV
    {
        public Reg_UserAddressMV()
        {
            AddressTypeList = new List<AddressTypeMV>();
            foreach (var addresstype in new DatabaseLayer.Pro_EccomerceDbEntities().AddressTypeTables.ToList())
            {
                AddressTypeList.Add(new AddressTypeMV() { AddressTypeID = addresstype.AddressTypeID, AddressType = addresstype.AddressType });
            }


            CountriesList = new List<CountryMV>();
            foreach (var country in new DatabaseLayer.Pro_EccomerceDbEntities().CountryTables.ToList())
            {
                CountriesList.Add(new CountryMV() { CountryID = country.CountryID, CountryTitle = country.CountryTitle });
            }

            CitiesList = new List<CityMV>();
            StatusList = new List<StatusMV>();
            foreach (var status in new DatabaseLayer.Pro_EccomerceDbEntities().StatusTables.ToList())
            {
                StatusList.Add(new StatusMV() { StatusID = status.StatusID, StatusTitle = status.StatusTitle });
            }
        }
        public Reg_UserAddressMV(int? userid)
        {
            AddressTypeList = new List<AddressTypeMV>();
            foreach (var addresstype in new DatabaseLayer.Pro_EccomerceDbEntities().AddressTypeTables.ToList())
            {
                AddressTypeList.Add(new AddressTypeMV() { AddressTypeID = addresstype.AddressTypeID, AddressType = addresstype.AddressType });
            }


            CountriesList = new List<CountryMV>();
            foreach (var country in new DatabaseLayer.Pro_EccomerceDbEntities().CountryTables.ToList())
            {
                CountriesList.Add(new CountryMV() { CountryID = country.CountryID, CountryTitle = country.CountryTitle });
            }

            CitiesList = new List<CityMV>();
            StatusList = new List<StatusMV>();
            foreach (var status in new DatabaseLayer.Pro_EccomerceDbEntities().StatusTables.ToList())
            {
                StatusList.Add(new StatusMV() { StatusID = status.StatusID, StatusTitle = status.StatusTitle });
            }

            list = new List<UserAddressMV>();
            foreach (var address in new DatabaseLayer.Pro_EccomerceDbEntities().UserAddressTables.Where(u => u.UserID == userid).ToList())
            {
                var addresstype = new DatabaseLayer.Pro_EccomerceDbEntities().AddressTypeTables.Find(address.AddressTypeID);
                var city = new DatabaseLayer.Pro_EccomerceDbEntities().CityTables.Find(address.CityID);
                var status = new DatabaseLayer.Pro_EccomerceDbEntities().StatusTables.Find(address.StatusID);

                list.Add(new UserAddressMV()
                {
                    UserAddressID = address.UserAddressID,
                    UserID = address.UserID,
                    AddressTypeID = address.AddressTypeID,
                    AddressType = addresstype.AddressType,
                    FullAddress = address.FullAddress,
                    CityID = address.CityID,
                    City = city.CityName,
                    PostalCode = address.PostalCode,
                    ContactNo = address.ContactNo,
                    StatusID = address.StatusID,
                    Status = status.StatusTitle
                });
            }

            UserID = Convert.ToInt32(userid);
        }
        public int UserAddressID { get; set; }
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Address Type")]
        public int AddressTypeID { get; set; }

        [Required(ErrorMessage = "Enter Full Address*")]
        [Display(Name = "Full Address")]
        [DataType(DataType.MultilineText)]
        public string FullAddress { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Select Country")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Select City")]
        public int CityID { get; set; }

        [Required(ErrorMessage = "Enter Postal Code*")]
        [Display(Name = "Postal Code")]
        [DataType(DataType.Text)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Enter Contact No*")]
        [Display(Name = "Contact No")]
        [RegularExpression("(^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$)", ErrorMessage = "Only Number's Allowed.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Required*")]
        [Display(Name = "Select Status")]
        public int StatusID { get; set; }
        public List<UserAddressMV> list { get; set; }
        public virtual List<AddressTypeMV> AddressTypeList { get; set; }
        public virtual List<CountryMV> CountriesList { get; set; }
        public virtual List<CityMV> CitiesList { get; set; }
        public virtual List<StatusMV> StatusList { get; set; }

    }
}