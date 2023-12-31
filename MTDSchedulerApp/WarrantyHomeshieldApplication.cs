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
    
    public partial class WarrantyHomeshieldApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarrantyHomeshieldApplication()
        {
            this.WarrantyHomeshieldProductApplications = new HashSet<WarrantyHomeshieldProductApplication>();
        }
    
        public int WarrantyHomeshieldApplicationId { get; set; }
        public int WarrantyHomeshieldUserId { get; set; }
        public int WarrantyCertificateForId { get; set; }
        public double MoistureMeterReading { get; set; }
        public string MoistureMeterReadingImagePath { get; set; }
        public string AffectedImagePath { get; set; }
        public bool IsFollowedSequence { get; set; }
        public Nullable<int> TopcoatEmultionProductId { get; set; }
        public string TopcoatEmultionProductName { get; set; }
        public string OtherEmultionProduct { get; set; }
        public double TotalInvoiceAmount { get; set; }
        public string InvoiceImagePath { get; set; }
        public double AfterMoistureMeterReading { get; set; }
        public string AfterMoistureMeterReadingImagePath { get; set; }
        public string AfterAffectedmagePath { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string CRMLeadId { get; set; }
        public Nullable<int> CRMSourceId { get; set; }
        public Nullable<int> CRMLeadSubStatusId { get; set; }
        public Nullable<System.DateTime> CRMLeadStatusUpdatedOn { get; set; }
        public string CRMRecordId { get; set; }
        public Nullable<bool> LDGenerated { get; set; }
        public Nullable<bool> LDWon { get; set; }
        public Nullable<bool> JobCompleted { get; set; }
        public Nullable<bool> IsRisingDampness { get; set; }
    
        public virtual CRMLeadSubStatu CRMLeadSubStatu { get; set; }
        public virtual CRMSource CRMSource { get; set; }
        public virtual WarrantyCertificateFor WarrantyCertificateFor { get; set; }
        public virtual WarrantyHomeshieldUser WarrantyHomeshieldUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarrantyHomeshieldProductApplication> WarrantyHomeshieldProductApplications { get; set; }
    }
}
