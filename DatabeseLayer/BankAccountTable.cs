//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabeseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class BankAccountTable
    {
        public int BankAccountID { get; set; }
        public int PaymentTypeID { get; set; }
        public string BankName { get; set; }
        public string AccountTitle { get; set; }
        public string AccountNo { get; set; }
        public string IBANNo { get; set; }
        public int StatusID { get; set; }
        public int CreatedBy_UserID { get; set; }
    
        public virtual PaymentTypeTable PaymentTypeTable { get; set; }
        public virtual StatusTable StatusTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
