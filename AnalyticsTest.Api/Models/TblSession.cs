using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblSession
    {
        public int SessionId { get; set; }
        public Guid SessionGuid { get; set; }
        public DateTime SessionStartDateTime { get; set; }
        public DateTime SessionLastDateTime { get; set; }
        public int SessionVisitorId { get; set; }

        public virtual TblVisitor SessionVisitor { get; set; }
    }
}
