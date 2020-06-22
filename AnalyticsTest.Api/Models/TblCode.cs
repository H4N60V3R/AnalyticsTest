using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblCode
    {
        public TblCode()
        {
            TblPageVisitPvBrowerCode = new HashSet<TblPageVisit>();
            TblPageVisitPvPlatformCode = new HashSet<TblPageVisit>();
            TblVisitor = new HashSet<TblVisitor>();
        }

        public int CodeId { get; set; }
        public string CodeName { get; set; }
        public string CodeDisplay { get; set; }
        public int CodeCgid { get; set; }
        public bool CodeIsActive { get; set; }
        public DateTime CodeCreateDatetime { get; set; }

        public virtual TblCodeGroup CodeCg { get; set; }
        public virtual ICollection<TblPageVisit> TblPageVisitPvBrowerCode { get; set; }
        public virtual ICollection<TblPageVisit> TblPageVisitPvPlatformCode { get; set; }
        public virtual ICollection<TblVisitor> TblVisitor { get; set; }
    }
}
