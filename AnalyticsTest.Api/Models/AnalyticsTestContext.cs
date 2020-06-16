using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnalyticsTest.Api.Models
{
    public partial class AnalyticsTestContext : DbContext
    {
        public AnalyticsTestContext(DbContextOptions<AnalyticsTestContext> options)
               : base(options)
        {
        }

        public virtual DbSet<VisitingLog> VisitingLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VisitingLog>(entity =>
            {
                entity.Property(e => e.DateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ip).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
