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
    
    public partial class tbl_BusinessQuery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_BusinessQuery()
        {
            this.BergerStepWiseDatas = new HashSet<BergerStepWiseData>();
        }
    
        public int BusinessQueryID { get; set; }
        public int DepartmentID { get; set; }
        public int QueryCategoryID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Query { get; set; }
        public string Attachment { get; set; }
        public string Location { get; set; }
        public string Source { get; set; }
        public string Medium { get; set; }
        public string Campaign { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Term { get; set; }
        public string Keyword { get; set; }
        public Nullable<bool> AcceptedTerms { get; set; }
        public string CRMLeadId { get; set; }
        public Nullable<int> CRMSourceId { get; set; }
        public Nullable<int> CRMLeadSubStatusId { get; set; }
        public Nullable<bool> isReadyForHousePaint { get; set; }
        public Nullable<System.DateTime> CRMLeadStatusUpdatedOn { get; set; }
        public string UrlReferrer { get; set; }
        public string CRMRecordId { get; set; }
        public string Adgroup { get; set; }
        public Nullable<int> CRMCampaignLocationId { get; set; }
        public string Content { get; set; }
        public string CRMPincode { get; set; }
        public string GoogleClickLeadId { get; set; }
        public string LeadGenerationSource { get; set; }
        public string HGSPinCode { get; set; }
        public Nullable<bool> LDGenerated { get; set; }
        public Nullable<bool> LDWon { get; set; }
        public Nullable<bool> JobCompleted { get; set; }
        public Nullable<bool> IsPincodeServicable { get; set; }
        public Nullable<bool> IsRecieveWhatsAppUpdate { get; set; }
        public Nullable<bool> IsSendToChatbot { get; set; }
        public Nullable<double> PaintableArea { get; set; }
        public string Depot { get; set; }
        public string CRMCity { get; set; }
        public string InitiatedFor { get; set; }
        public string AltTelephone { get; set; }
        public string PaintingType { get; set; }
        public string SiteType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BergerStepWiseData> BergerStepWiseDatas { get; set; }
        public virtual CRMLeadSubStatu CRMLeadSubStatu { get; set; }
        public virtual CRMSource CRMSource { get; set; }
    }
}
