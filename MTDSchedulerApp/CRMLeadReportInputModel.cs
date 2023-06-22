using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDSchedulerApp
{
    public class CRMLeadReportInputModel
    {
        public int CRMSourceId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        //public IEnumerable<CRMSourceModel> SourceList { get; set; }
        //public List<CRMLeadReportOutputModel> Data { get; set; }
        //public string Command { get; set; }
    }
}
