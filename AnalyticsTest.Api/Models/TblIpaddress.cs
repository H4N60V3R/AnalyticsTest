using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblIpaddress
    {
        public TblIpaddress()
        {
            TblVisitor = new HashSet<TblVisitor>();
        }

        public int IaId { get; set; }
        public string IaIp { get; set; }
        public int IaContryId { get; set; }
        public int IaCityId { get; set; }
        public string IaIsp { get; set; }

        public virtual ICollection<TblVisitor> TblVisitor { get; set; }
    }
}
