using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblLog
    {
        public TblLog()
        {
            TblPageVisit = new HashSet<TblPageVisit>();
        }

        public int LogId { get; set; }
        public string LogRaw { get; set; }
        public DateTime LogDateTime { get; set; }

        public virtual ICollection<TblPageVisit> TblPageVisit { get; set; }
    }
}
