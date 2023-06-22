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
    
    public partial class WarrantyCertificateProductDetail
    {
        public int WarrantyCertificateProductDetailId { get; set; }
        public int WarrantyCertificateUserId { get; set; }
        public int WarrantyCertificateProductId { get; set; }
        public string Shade { get; set; }
        public double Quantity { get; set; }
        public string Batch { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public string InvoiceNo { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<bool> IsPrimerApplicable { get; set; }
        public Nullable<int> PrimerProduct1Id { get; set; }
        public Nullable<double> PrimerProduct1Quantity { get; set; }
        public Nullable<int> PrimerProduct2Id { get; set; }
        public Nullable<double> PrimerProduct2Quantity { get; set; }
        public Nullable<int> PrimerProduct3Id { get; set; }
        public Nullable<double> PrimerProduct3Quantity { get; set; }
        public Nullable<int> PrimerProduct4Id { get; set; }
        public Nullable<double> PrimerProduct4Quantity { get; set; }
        public Nullable<int> PrimerProduct5Id { get; set; }
        public Nullable<double> PrimerProduct5Quantity { get; set; }
    
        public virtual WarrantyCertificateUser WarrantyCertificateUser { get; set; }
    }
}
