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
    
    public partial class WishListTable
    {
        public int WishListID { get; set; }
        public int WishList_UserID { get; set; }
        public int ProductHeaderID { get; set; }
        public System.DateTime AddDate { get; set; }
    
        public virtual ProductHeaderTable ProductHeaderTable { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
