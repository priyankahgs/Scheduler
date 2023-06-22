using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Reflection;

namespace MTDSchedulerApp
{
    class Program
    {
        //private BergerPhase3Entities db = new BergerPhase3Entities();
        static void Main(string[] args)
        {
            UpdateDealerDataFromAPI();
        }

        static void UpdateDealerDataFromAPI()
        {
            BergerPhase3Entities db = new BergerPhase3Entities();
            LogException.Log("Inside UpdateDealerDataFromAPI().");
            CRMLeadReportInputModel model = new CRMLeadReportInputModel();
            try
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                model.FromDate = Convert.ToDateTime(firstDay).ToString("d");
                //model.FromDate = DateTime.Now.ToString("d");

                DateTime ToDate = DateTime.Now;


                //var getmonth =new DateTime(ToDate.Year, ToDate.Month, 1);
                ToDate = ToDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                model.ToDate = ToDate.ToString("d");
                DateTime MailtoDate = new DateTime(ToDate.Year, ToDate.Month, ToDate.Day).AddMinutes(330).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                DateTime currentDateTime = DateTime.Now;

                LogException.Log(string.Format("Fetching Data From {0} To {1}", model.FromDate, model.ToDate));



                var data = GetList(model);
                string emailFileTemplate = string.Empty;
                string dataupdate = string.Empty;

                if (data != null && data.Count > 0)
                {
                    LogException.Log("Data Count : " + data.Count);

                    DataTable dataTable = ToDataTable(data);
                    string errorMessage = string.Empty;
                    dataupdate = UpdateDealerData(dataTable, out errorMessage);
                    LogException.Log("result of data update : " + dataupdate);
                    //Send Mail Functionality                       
                    if (dataupdate == "Failure" && !string.IsNullOrWhiteSpace(errorMessage))
                    {
                        LogException.Log("Error while updating dealer data : " + errorMessage);
                        return;
                    }

                }

            }
            catch (Exception ex)
            {
                LogException.Log("Error in UpdateDealerDataFromAPI() Exception : " + ex.Message + " => InnerExecption : " + ex.InnerException + "");
            }
        }

        static string UpdateDealerData(DataTable dt, out string errorMessage)
        {
            errorMessage = string.Empty;
            try

            {
                string apiResponse = string.Empty;
                BergerPhase3Entities db = new BergerPhase3Entities();
                  DataSet ds = new DataSet();
                string AuthKey = ConfigurationManager.AppSettings["API.CRMBerger.B2BApi.Authorization"];

                string urlToCreate = string.Format("{0}{1}", ConfigurationManager.AppSettings["API.CRMBerger.B2BApi.BaseUrl"], "B2BLEADS/WebServiceCustomerMaster.asmx/FetchBulkCustomers");

                //Convert datatable to dataset and add it to the workbook as worksheet
                ds.Tables.Add(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var dict = new Dictionary<string, string>();
                    dict.Add("MobileNo", dr["Telephone"].ToString());

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("AuthKey", AuthKey);
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                        ServicePointManager.SecurityProtocol = (SecurityProtocolType)48 | (SecurityProtocolType)192 | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                        HttpResponseMessage res = client.PostAsync(urlToCreate, new FormUrlEncodedContent(dict)).Result;

                        var result = res.Content.ReadAsStringAsync().Result;
                        string Finalresult = result.ToString();
                        apiResponse = Finalresult;
                        dynamic json = JObject.Parse(result);

                        LogException.Log("Input Data : " + result);
                        if (json.Data.ToString() != "[]")
                        {
                            CRMLeadReportOutputModel response = new CRMLeadReportOutputModel();
                            response.Customer_Name = json.Data[0]["Customer Name"].ToString();
                            response.Customer_mobile = json.Data[0]["Customer Mobile"].ToString();
                            response.Lead_ID = json.Data[0]["Lead Id"].ToString();
                            response.Lead_Status = json.Data[0]["Lead Status"].ToString();
                            response.Lead_Created_Date = json.Data[0]["Lead Created On"].ToString();
                            response.Cancellation_reason = json.Data[0]["Cancel Reason"].ToString();
                            response.Assigned_Depot = json.Data[0]["Depot"].ToString();
                            response.Assigned_ASM = json.Data[0]["Assigned ASM"].ToString();
                            response.Assigned_TSI = json.Data[0]["Assigned TSI"].ToString();
                            response.Converted_Dealer_code = json.Data[0]["Converted Dealer Code"].ToString();
                            response.Converted_Dealer_type = json.Data[0]["Converted Dealer Type"].ToString();
                            response.Converted_sub_dealer_code = json.Data[0]["Converted Sub Dealer Code"].ToString();

                            response.Business_Line = json.Data[0]["Business Line"].ToString();
                            response.GST_YorN = json.Data[0]["GST Y/N"].ToString();
                            response.Gst_No = json.Data[0]["GST No."].ToString();
                            response.Shop_Name = json.Data[0]["Shop Name"].ToString();
                            response.Shop_Address_1 = json.Data[0]["Shop Address 1"].ToString();
                            response.Shop_Address_2 = json.Data[0]["Shop Address 2"].ToString();
                            response.Shop_City = json.Data[0]["Shop City"].ToString();
                            response.Shop_State = json.Data[0]["Shop State"].ToString();
                            response.Shop_Pin = json.Data[0]["Shop Pin"].ToString();

                            response.Home_Address_2 = json.Data[0]["Home Address 2"].ToString();
                            response.Home_City = json.Data[0]["Home City"].ToString();
                            response.Home_State = json.Data[0]["Home State"].ToString();
                            response.Home_Pin = json.Data[0]["Home Pin"].ToString();
                            response.Current_sales_value_lakh = json.Data[0]["Current Sales Value / Month (In Lakh)"].ToString();
                            response.Start_Dealing_Berger_product_Within = json.Data[0]["Start Dealing Berger product Within"].ToString();
                            response.Current_segment = json.Data[0]["Segments"].ToString();
                            response.Current_brands = json.Data[0]["Brands"].ToString();
                            response.Fresh_Lead_Last_Followup_Status = json.Data[0]["Fresh Lead Last Followup Status"].ToString();
                            response.Fresh_Lead_Last_Followup_On = json.Data[0]["Fresh Lead Last Followup On"].ToString();
                            response.Fresh_Lead_Next_Followup_On = json.Data[0]["Fresh Lead  Next Followup On"].ToString();
                            response.Lead_Remarks_Date = json.Data[0]["Lead Remarks by ASM/TSI Entered On"].ToString();
                            response.Lead_Remarks = json.Data[0]["Lead Remarks by ASM/TSI"].ToString();


                            var TelephoneNo = dr["Telephone"].ToString();

                            var dataexists = (from de in db.tbl_BusinessDealer where de.Telephone == TelephoneNo select de).FirstOrDefault();
                            var dataexistsAdditional = (from de in db.tbl_BusinessDealerAdditionalData where de.BusinessDealerID == dataexists.BusinessDealerID select de).FirstOrDefault();

                            if (dataexistsAdditional == null)
                            {
                                tbl_BusinessDealerAdditionalData tbAddData = new tbl_BusinessDealerAdditionalData();
                                tbAddData.BusinessDealerID = dataexists.BusinessDealerID;
                                tbAddData.Customer_Mobile = response.Customer_mobile;
                                tbAddData.Call_Center_status = response.Call_Center_status;
                                tbAddData.Call_Center_last_Followup_Date = response.Call_Center_last_Followup_Date;
                                tbAddData.Call_Center_next_Followup_Date = response.Call_Center_next_Followup_Date;
                                tbAddData.Customer_Name = response.Customer_Name;

                                tbAddData.separate_column_not_needed_since_there_in_enquiry = response.separate_column_not_needed_since_there_in_enquiry;
                                tbAddData.Lead_ID = response.Lead_ID;
                                tbAddData.Lead_Status = response.Lead_Status;
                                tbAddData.Lead_Created_Date = response.Lead_Created_Date;
                                tbAddData.Cancellation_reason = response.Cancellation_reason;


                                tbAddData.Cancellation_remarks = response.Cancellation_remarks;
                                tbAddData.Assigned_Depot = response.Assigned_Depot;
                                tbAddData.Assigned_ASM = response.Assigned_ASM;
                                tbAddData.Assigned_TSI = response.Assigned_TSI;
                                tbAddData.Converted_Dealer_code = response.Converted_Dealer_code;


                                tbAddData.Converted_Dealer_type = response.Converted_Dealer_type;
                                tbAddData.Converted_sub_dealer_code = response.Converted_sub_dealer_code;
                                tbAddData.Business_Line = response.Business_Line;
                                tbAddData.GST_YorN = response.GST_YorN;
                                tbAddData.Gst_No = response.Gst_No;

                                tbAddData.Shop_Name = response.Shop_Name;
                                tbAddData.Shop_Address_1 = response.Shop_Address_1;
                                tbAddData.Shop_Address_2 = response.Shop_Address_2;
                                tbAddData.Shop_City = response.Shop_City;
                                tbAddData.Shop_State = response.Shop_State;

                                tbAddData.Shop_Pin = response.Shop_Pin;
                                tbAddData.Current_sales_value_lakh = response.Current_sales_value_lakh;
                                tbAddData.Start_Dealing_Berger_product_Within = response.Start_Dealing_Berger_product_Within;
                                tbAddData.Current_segment = response.Current_segment;
                                tbAddData.Current_brands = response.Current_brands;

                                tbAddData.Lead_Remarks = response.Lead_Remarks;
                                tbAddData.Lead_Remarks_Date = response.Lead_Remarks_Date;
                                tbAddData.Fresh_Lead_Last_Followup_Status = response.Fresh_Lead_Last_Followup_Status;
                                tbAddData.Fresh_Lead_Last_Followup_On = response.Fresh_Lead_Last_Followup_On;
                                tbAddData.Fresh_Lead_Next_Followup_On = response.Fresh_Lead_Next_Followup_On;

                                tbAddData.Home_Address_2 = response.Home_Address_2;
                                tbAddData.Home_City = response.Home_City;
                                tbAddData.Home_State = response.Home_State;
                                tbAddData.Home_Pin = response.Home_Pin;
                                tbAddData.CreatedOn = DateTime.Now; 
                                db.tbl_BusinessDealerAdditionalData.Add(tbAddData);
                                db.SaveChanges();

                                LogException.Log("Data Inserted For BusinessDealerId : " + tbAddData.BusinessDealerID);

                            }
                            else 
                            {
                                dataexistsAdditional.Customer_Mobile = response.Customer_mobile;
                                dataexistsAdditional.Call_Center_status = response.Call_Center_status;
                                dataexistsAdditional.Call_Center_last_Followup_Date = response.Call_Center_last_Followup_Date;
                                dataexistsAdditional.Call_Center_next_Followup_Date = response.Call_Center_next_Followup_Date;
                                dataexistsAdditional.Customer_Name = response.Customer_Name;

                                dataexistsAdditional.separate_column_not_needed_since_there_in_enquiry = response.separate_column_not_needed_since_there_in_enquiry;
                                dataexistsAdditional.Lead_ID = response.Lead_ID;
                                dataexistsAdditional.Lead_Status = response.Lead_Status;
                                dataexistsAdditional.Lead_Created_Date = response.Lead_Created_Date;
                                dataexistsAdditional.Cancellation_reason = response.Cancellation_reason;


                                dataexistsAdditional.Cancellation_remarks = response.Cancellation_remarks;
                                dataexistsAdditional.Assigned_Depot = response.Assigned_Depot;
                                dataexistsAdditional.Assigned_ASM = response.Assigned_ASM;
                                dataexistsAdditional.Assigned_TSI = response.Assigned_TSI;
                                dataexistsAdditional.Converted_Dealer_code = response.Converted_Dealer_code;


                                dataexistsAdditional.Converted_Dealer_type = response.Converted_Dealer_type;
                                dataexistsAdditional.Converted_sub_dealer_code = response.Converted_sub_dealer_code;
                                dataexistsAdditional.Business_Line = response.Business_Line;
                                dataexistsAdditional.GST_YorN = response.GST_YorN;
                                dataexistsAdditional.Gst_No = response.Gst_No;

                                dataexistsAdditional.Shop_Name = response.Shop_Name;
                                dataexistsAdditional.Shop_Address_1 = response.Shop_Address_1;
                                dataexistsAdditional.Shop_Address_2 = response.Shop_Address_2;
                                dataexistsAdditional.Shop_City = response.Shop_City;
                                dataexistsAdditional.Shop_State = response.Shop_State;

                                dataexistsAdditional.Shop_Pin = response.Shop_Pin;
                                dataexistsAdditional.Current_sales_value_lakh = response.Current_sales_value_lakh;
                                dataexistsAdditional.Start_Dealing_Berger_product_Within = response.Start_Dealing_Berger_product_Within;
                                dataexistsAdditional.Current_segment = response.Current_segment;
                                dataexistsAdditional.Current_brands = response.Current_brands;

                                dataexistsAdditional.Lead_Remarks = response.Lead_Remarks;
                                dataexistsAdditional.Lead_Remarks_Date = response.Lead_Remarks_Date;
                                dataexistsAdditional.Fresh_Lead_Last_Followup_Status = response.Fresh_Lead_Last_Followup_Status;
                                dataexistsAdditional.Fresh_Lead_Last_Followup_On = response.Fresh_Lead_Last_Followup_On;
                                dataexistsAdditional.Fresh_Lead_Next_Followup_On = response.Fresh_Lead_Next_Followup_On;

                                dataexistsAdditional.Home_Address_2 = response.Home_Address_2;
                                dataexistsAdditional.Home_City = response.Home_City;
                                dataexistsAdditional.Home_State = response.Home_State;
                                dataexistsAdditional.Home_Pin = response.Home_Pin;
                                dataexistsAdditional.UpdatedOn = DateTime.Now;
                                dataexistsAdditional.BusinessDealerID = dataexists.BusinessDealerID;
                                db.SaveChanges();

                                LogException.Log("Data Updated For BusinessDealerId : " + dataexistsAdditional.BusinessDealerID);
                            }
                            
                             
                        }
                    }
                }

                return "Success";
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                LogException.Log("Exception Occurred Output Failure In Data : " + ex.Message);

                LogException.Log("Exception Occurred Output Failure In Data StackTrace: " + ex.StackTrace);
                return "Failure"; 
            }
        }


        static List<CRMLeadReportOutputModel> GetList(CRMLeadReportInputModel model)
        {
            BergerPhase3Entities db = new BergerPhase3Entities();
            DateTime _fromDate = Convert.ToDateTime(model.FromDate);
            DateTime _toDate = Convert.ToDateTime(model.ToDate);
            int crmSourceId = model.CRMSourceId;

            List<CRMLeadReportOutputModel> outputModels = new List<CRMLeadReportOutputModel>();

            string jsonCRMJsonFilePath = ConfigurationManager.AppSettings["CRMJsonFilePath"];


            string json1 = string.Empty;

            DateTime fromDate = new DateTime(_fromDate.Year, _fromDate.Month, _fromDate.Day).AddMinutes(330).Date.AddHours(00).AddMinutes(00).AddSeconds(00);
            DateTime toDate = new DateTime(_toDate.Year, _toDate.Month, _toDate.Day).AddMinutes(330).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            try
            {

                var BusinessDealer = (from bq in db.tbl_BusinessDealer
                                     where bq.CreatedDate >= fromDate && bq.CreatedDate <= toDate  
                                     select new CRMLeadReportOutputModel
                                     {
                                         Telephone = bq.Telephone
                                     }
                                ).ToList();


                var data = BusinessDealer.ToList();


                if (data != null && data.Count > 0)
                {

                    outputModels = data;
                }
            }
            catch (Exception exp)
            {
                LogException.Log("Error occured while generating report");
                if (!string.IsNullOrWhiteSpace(exp.StackTrace))
                {
                    LogException.Log(exp.StackTrace);
                }
                throw exp;
            }
            return outputModels;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows                   
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable

            int rowCount = 1;
            dataTable.Columns.Add("No", typeof(int)).SetOrdinal(0);
            foreach (DataRow dr in dataTable.Rows)
            {
                dr[0] = rowCount;
                rowCount++;
            }
            return dataTable;
        }
    }
}
