//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MTDSchedulerApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class WarrantyCertificateUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarrantyCertificateUser()
        {
            this.WarrantyCertificateOtherDetails = new HashSet<WarrantyCertificateOtherDetail>();
            this.WarrantyCertificateProductDetails = new HashSet<WarrantyCertificateProductDetail>();
        }
    
        public int WarrantyCertificateUserId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public System.DateTime JobCompletionDate { get; set; }
        public string Address { get; set; }
        public string SiteAddress { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> WarrantyTypeId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyCertificateOtherDetail> WarrantyCertificateOtherDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyCertificateProductDetail> WarrantyCertificateProductDetails { get; set; }
    }
}