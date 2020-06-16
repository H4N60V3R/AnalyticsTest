using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsTest.Api.Models
{
    public partial class VisitingLog
    {
        [Key]
        public int VisitLogId { get; set; }
        [StringLength(50)]
        public string Ip { get; set; }
        public DateTime DateTime { get; set; }
    }
}
