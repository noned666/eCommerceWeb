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
    
    public partial class SeasonTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeasonTable()
        {
            this.SeasonDiscountTables = new HashSet<SeasonDiscountTable>();
        }
    
        public int SeasonID { get; set; }
        public string SeasonTitle { get; set; }
        public System.DateTime SeasonStartDate { get; set; }
        public System.DateTime SeasonEndDate { get; set; }
        public int CreatedBy_UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeasonDiscountTable> SeasonDiscountTables { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}