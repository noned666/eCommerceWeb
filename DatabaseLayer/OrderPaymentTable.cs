//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderPaymentTable
    {
        public int OrderPaymentID { get; set; }
        public int OrderHeaderID { get; set; }
        public double TotalPayment { get; set; }
        public string PaymentGateWay { get; set; }
        public int PaymentTypeID { get; set; }
        public int PaymentStatusID { get; set; }
    
        public virtual OrderHeaderTable OrderHeaderTable { get; set; }
        public virtual PaymentStatusTable PaymentStatusTable { get; set; }
        public virtual PaymentTypeTable PaymentTypeTable { get; set; }
    }
}
