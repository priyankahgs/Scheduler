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
    
    public partial class CRMLinkedinLead
    {
        public int CRMLinkedinLeadId { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public System.DateTime PostedOn { get; set; }
        public string Source { get; set; }
        public string Medium { get; set; }
        public string Campaign { get; set; }
        public string Query { get; set; }
        public string CRMLeadId { get; set; }
        public int CRMLeadSyncStatusId { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CRMLeadSubStatusId { get; set; }
        public Nullable<System.DateTime> CRMLeadStatusUpdatedOn { get; set; }
        public string CRMRecordId { get; set; }
        public Nullable<int> CRMCampaignLocationId { get; set; }
        public string CRMPincode { get; set; }
        public Nullable<bool> LDGenerated { get; set; }
        public Nullable<bool> LDWon { get; set; }
        public Nullable<bool> JobCompleted { get; set; }
    
        public virtual CRMLeadSubStatu CRMLeadSubStatu { get; set; }
        public virtual CRMLeadSyncStatu CRMLeadSyncStatu { get; set; }
    }
}
