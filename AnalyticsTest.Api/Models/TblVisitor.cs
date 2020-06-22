using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblVisitor
    {
        public TblVisitor()
        {
            TblPageVisit = new HashSet<TblPageVisit>();
            TblSession = new HashSet<TblSession>();
        }

        public int VisitorId { get; set; }
        public int VisitorIpid { get; set; }
        public int VisitorTypeCodeId { get; set; }
        public DateTime VisitorCreateDateTime { get; set; }

        public virtual TblIpaddress VisitorIp { get; set; }
        public virtual TblCode VisitorTypeCode { get; set; }
        public virtual ICollection<TblPageVisit> TblPageVisit { get; set; }
        public virtual ICollection<TblSession> TblSession { get; set; }
    }
}
