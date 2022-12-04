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
    
    public partial class ProductDetailTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductDetailTable()
        {
            this.CompareTables = new HashSet<CompareTable>();
            this.OrderDetailTables = new HashSet<OrderDetailTable>();
        }
    
        public int ProductDetailID { get; set; }
        public int ProductHeaderID { get; set; }
        public int ColorTypeID { get; set; }
        public int SizeTypeLevel { get; set; }
        public int UnitID { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Barcode { get; set; }
        public int StatusID { get; set; }
        public int CreatedBy_UserID { get; set; }
        public int UpdateBy_UserID { get; set; }
    
        public virtual ColorTypeTable ColorTypeTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompareTable> CompareTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetailTable> OrderDetailTables { get; set; }
        public virtual ProductHeaderTable ProductHeaderTable { get; set; }
        public virtual SizeTypeByLevelTable SizeTypeByLevelTable { get; set; }
        public virtual StatusTable StatusTable { get; set; }
        public virtual StatusTable StatusTable1 { get; set; }
        public virtual UnitTable UnitTable { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual UserTable UserTable1 { get; set; }
        public virtual UserTable UserTable2 { get; set; }
        public virtual UserTable UserTable3 { get; set; }
        public virtual UserTable UserTable4 { get; set; }
    }
}
