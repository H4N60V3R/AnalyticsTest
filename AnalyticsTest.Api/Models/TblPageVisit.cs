using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblPageVisit
    {
        public int PvId { get; set; }
        public int PvVisitorId { get; set; }
        public int PvLogId { get; set; }
        public string PvPageUrl { get; set; }
        public string PvReferrer { get; set; }
        public string PvWindowSize { get; set; }
        public int? PvBrowerCodeId { get; set; }
        public string PvBrowerInfo { get; set; }
        public int? PvPlatformCodeId { get; set; }
        public string PvUserAgent { get; set; }
        public DateTime PvDateTime { get; set; }

        public virtual TblCode PvBrowerCode { get; set; }
        public virtual TblLog PvLog { get; set; }
        public virtual TblCode PvPlatformCode { get; set; }
        public virtual TblVisitor PvVisitor { get; set; }
    }
}
