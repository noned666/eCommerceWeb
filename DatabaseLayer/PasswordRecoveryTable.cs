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
    
    public partial class PasswordRecoveryTable
    {
        public int PasswordRecoveryID { get; set; }
        public int UserID { get; set; }
        public string RecoveryCode { get; set; }
        public System.DateTime RecoveryCodeExpiryDateTime { get; set; }
        public Nullable<bool> RecoveryStatus { get; set; }
        public string OldPassword { get; set; }
    }
}