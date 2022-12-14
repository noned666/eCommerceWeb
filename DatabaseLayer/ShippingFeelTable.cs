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
    
    public partial class ShippingFeelTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShippingFeelTable()
        {
            this.OrderHeaderTables = new HashSet<OrderHeaderTable>();
        }
    
        public int ShippingFeelID { get; set; }
        public int CityID { get; set; }
        public double ShippingFee { get; set; }
        public int DeliveryTimeinDays { get; set; }
        public Nullable<int> StatusID { get; set; }
    
        public virtual CityTable CityTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderHeaderTable> OrderHeaderTables { get; set; }
        public virtual StatusTable StatusTable { get; set; }
    }
}
