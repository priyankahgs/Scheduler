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
    
    public partial class tbl_AskConsultant
    {
        public int AskConsultantID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Query { get; set; }
        public string Attachment1 { get; set; }
        public string Attachment2 { get; set; }
        public string Attachment3 { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Source { get; set; }
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
        public Nullable<double> PaintableArea { get; set; }
        public string Depot { get; set; }
        public string CRMCity { get; set; }
        public string PaintingType { get; set; }
        public string SiteType { get; set; }
    
        public virtual CRMLeadSubStatu CRMLeadSubStatu { get; set; }
        public virtual CRMSource CRMSource { get; set; }
    }
}