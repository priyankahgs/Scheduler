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
    
    public partial class tbl_IndustrialUsers_Enquiry
    {
        public int ProductEnquiryID { get; set; }
        public string Category { get; set; }
        public string Product { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> CRMLeadStatusUpdatedOn { get; set; }
        public string CRMLeadId { get; set; }
        public Nullable<int> CRMSourceId { get; set; }
        public Nullable<int> CRMLeadSubStatusId { get; set; }
        public string CRMRecordId { get; set; }
        public Nullable<int> CRMCampaignLocationId { get; set; }
        public string CRMPincode { get; set; }
        public Nullable<bool> LDGenerated { get; set; }
        public Nullable<bool> LDWon { get; set; }
        public Nullable<bool> JobCompleted { get; set; }
    
        public virtual CRMLeadSubStatu CRMLeadSubStatu { get; set; }
        public virtual CRMSource CRMSource { get; set; }
    }
}
