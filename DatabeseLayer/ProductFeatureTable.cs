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
    
    public partial class ProductFeatureTable
    {
        public int ProductFeatureID { get; set; }
        public int PruductHeaderID { get; set; }
        public string ProductFeature { get; set; }
        public int CreatedBy_UserID { get; set; }
        public int UpdateBy_UserID { get; set; }
        public int StatusID { get; set; }
    
        public virtual ProductHeaderTable ProductHeaderTable { get; set; }
        public virtual StatusTable StatusTable { get; set; }
        public virtual UserTable UserTable { get; set; }
        public virtual UserTable UserTable1 { get; set; }
    }
}
