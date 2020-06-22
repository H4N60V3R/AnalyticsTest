using System;
using System.Collections.Generic;

namespace AnalyticsTest.Api.Models
{
    public partial class TblCodeGroup
    {
        public TblCodeGroup()
        {
            TblCode = new HashSet<TblCode>();
        }

        public int CgId { get; set; }
        public string CgName { get; set; }
        public string CgDisplay { get; set; }
        public DateTime CgCreateDateTime { get; set; }

        public virtual ICollection<TblCode> TblCode { get; set; }
    }
}
