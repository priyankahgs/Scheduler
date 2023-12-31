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
    
    public partial class WarrantyHomeshieldUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarrantyHomeshieldUser()
        {
            this.WarrantyHomeshieldApplications = new HashSet<WarrantyHomeshieldApplication>();
            this.WarrantyHomeshieldOtherDetails = new HashSet<WarrantyHomeshieldOtherDetail>();
            this.WarrantyHomeshieldUploadDocuments = new HashSet<WarrantyHomeshieldUploadDocument>();
        }
    
        public int WarrantyHomeshieldUserId { get; set; }
        public string Name { get; set; }
        public System.DateTime PaintingCompletionDate { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public Nullable<int> WarrantyStateId { get; set; }
        public string OtherState { get; set; }
        public Nullable<int> WarrantyCityId { get; set; }
        public string OtherCity { get; set; }
        public Nullable<int> WarrantyPincodeId { get; set; }
        public Nullable<int> OtherPincode { get; set; }
        public string Address { get; set; }
        public string SiteAddress { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime PaintingStartDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyHomeshieldApplication> WarrantyHomeshieldApplications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyHomeshieldOtherDetail> WarrantyHomeshieldOtherDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyHomeshieldUploadDocument> WarrantyHomeshieldUploadDocuments { get; set; }
        public virtual WarrantyPincode WarrantyPincode { get; set; }
        public virtual WarrantyState WarrantyState { get; set; }
    }
}
