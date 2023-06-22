using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MTDSchedulerApp
{
   public  class CRMLeadReportOutputModel
    {
        public string Telephone { get; set; }
        public string Home_Address_2 { get; set; }
        public string Fresh_Lead_Last_Followup_Status { get; set; }
        public string Fresh_Lead_Last_Followup_On { get; set; }
        public string Fresh_Lead_Next_Followup_On { get; set; }

        public string Home_City { get; set; }
        public string Home_State { get; set; }
        public string Home_Pin { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMsg { get; set; }
        public string BusinessDealerID { get; set; }
        [property: JsonPropertyName("Call Center status")]
        public string Call_Center_status { get; set; }
        public string Call_Center_last_Followup_Date { get; set; }
        public string Call_Center_next_Followup_Date { get; set; }


        [JsonPropertyName("Customer Name")]
        public string Customer_Name { get; set; }

        public string Customer_mobile { get; set; }
        public string separate_column_not_needed_since_there_in_enquiry { get; set; }
        public string Lead_ID { get; set; }
        public string Lead_Status { get; set; }
        public string Lead_Created_Date { get; set; }
        public string Cancellation_reason { get; set; }
        public string Cancellation_remarks { get; set; }
        public string Assigned_Depot { get; set; }
        public string Assigned_ASM { get; set; }
        public string Assigned_TSI { get; set; }
        public string Converted_Dealer_code { get; set; }
        public string Converted_Dealer_type { get; set; }
        public string Converted_sub_dealer_code { get; set; }
        public string Business_Line { get; set; }
        public string GST_YorN { get; set; }
        public string Gst_No { get; set; }
        public string Shop_Name { get; set; }
        public string Shop_Address_1 { get; set; }
        public string Shop_Address_2 { get; set; }
        public string Shop_City { get; set; }
        public string Shop_State { get; set; }
        public string Shop_Pin { get; set; }
        public string Current_sales_value_lakh { get; set; }
        public string Start_Dealing_Berger_product_Within { get; set; }
        public string Current_segment { get; set; }
        public string Current_brands { get; set; }
        public string Lead_Remarks { get; set; }
        public string Lead_Remarks_Date { get; set; }
    }
}
