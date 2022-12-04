using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceUI.Models
{
    public class UserAddressMV
    {
        public int UserAddressID { get; set; }
        public int UserID { get; set; }
        public int AddressTypeID { get; set; }
        public string AddressType { get; set; }
        public string FullAddress { get; set; }
        public int CityID { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ContactNo { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
    }
}