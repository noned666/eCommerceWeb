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
    
    public partial class ColorTypeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ColorTypeTable()
        {
            this.ProductDetailTables = new HashSet<ProductDetailTable>();
        }
    
        public int ColorTypeID { get; set; }
        public string ColorTitle { get; set; }
        public string ColorCode { get; set; }
        public int StatusID { get; set; }
    
        public virtual StatusTable StatusTable { get; set; }
        public virtual StatusTable StatusTable1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetailTable> ProductDetailTables { get; set; }
    }
}
