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
    
    public partial class StatusTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusTable()
        {
            this.BankAccountTables = new HashSet<BankAccountTable>();
            this.BrandTables = new HashSet<BrandTable>();
            this.ColorTypeTables = new HashSet<ColorTypeTable>();
            this.ColorTypeTables1 = new HashSet<ColorTypeTable>();
            this.CustomerReviewImageTables = new HashSet<CustomerReviewImageTable>();
            this.CustomerReviewImageTables1 = new HashSet<CustomerReviewImageTable>();
            this.CustomerReviewTables = new HashSet<CustomerReviewTable>();
            this.DiscountTables = new HashSet<DiscountTable>();
            this.OrderStatusTables = new HashSet<OrderStatusTable>();
            this.ProductDetailTables = new HashSet<ProductDetailTable>();
            this.ProductDetailTables1 = new HashSet<ProductDetailTable>();
            this.ProductFeatureTables = new HashSet<ProductFeatureTable>();
            this.ProductTagTables = new HashSet<ProductTagTable>();
            this.SeasonDiscountTables = new HashSet<SeasonDiscountTable>();
            this.ShippingFeelTables = new HashSet<ShippingFeelTable>();
            this.SizeTypeByLevelTables = new HashSet<SizeTypeByLevelTable>();
            this.SubCategoryTables = new HashSet<SubCategoryTable>();
            this.UserAddressTables = new HashSet<UserAddressTable>();
        }
    
        public int StatusID { get; set; }
        public string StatusTitle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankAccountTable> BankAccountTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrandTable> BrandTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColorTypeTable> ColorTypeTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ColorTypeTable> ColorTypeTables1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerReviewImageTable> CustomerReviewImageTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerReviewImageTable> CustomerReviewImageTables1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerReviewTable> CustomerReviewTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiscountTable> DiscountTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderStatusTable> OrderStatusTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetailTable> ProductDetailTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDetailTable> ProductDetailTables1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductFeatureTable> ProductFeatureTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTagTable> ProductTagTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeasonDiscountTable> SeasonDiscountTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShippingFeelTable> ShippingFeelTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SizeTypeByLevelTable> SizeTypeByLevelTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubCategoryTable> SubCategoryTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAddressTable> UserAddressTables { get; set; }
    }
}