using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnalyticsTest.Api.Models
{
    public partial class StartDone_AnalyticsContext : DbContext
    {
        public StartDone_AnalyticsContext()
        {
        }

        public StartDone_AnalyticsContext(DbContextOptions<StartDone_AnalyticsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCode> TblCode { get; set; }
        public virtual DbSet<TblCodeGroup> TblCodeGroup { get; set; }
        public virtual DbSet<TblIpaddress> TblIpaddress { get; set; }
        public virtual DbSet<TblLog> TblLog { get; set; }
        public virtual DbSet<TblPageVisit> TblPageVisit { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblSession> TblSession { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblVisitor> TblVisitor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCode>(entity =>
            {
                entity.HasKey(e => e.CodeId);

                entity.ToTable("Tbl_Code");

                entity.Property(e => e.CodeId).HasColumnName("Code_ID");

                entity.Property(e => e.CodeCgid).HasColumnName("Code_CGID");

                entity.Property(e => e.CodeCreateDatetime).HasColumnName("Code_CreateDatetime");

                entity.Property(e => e.CodeDisplay)
                    .IsRequired()
                    .HasColumnName("Code_Display")
                    .HasMaxLength(128);

                entity.Property(e => e.CodeIsActive).HasColumnName("Code_IsActive");

                entity.Property(e => e.CodeName)
                    .IsRequired()
                    .HasColumnName("Code_Name")
                    .HasMaxLength(128);

                entity.HasOne(d => d.CodeCg)
                    .WithMany(p => p.TblCode)
                    .HasForeignKey(d => d.CodeCgid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodeGroup");
            });

            modelBuilder.Entity<TblCodeGroup>(entity =>
            {
                entity.HasKey(e => e.CgId);

                entity.ToTable("Tbl_CodeGroup");

                entity.Property(e => e.CgId).HasColumnName("CG_ID");

                entity.Property(e => e.CgCreateDateTime).HasColumnName("CG_CreateDateTime");

                entity.Property(e => e.CgDisplay)
                    .IsRequired()
                    .HasColumnName("CG_Display")
                    .HasMaxLength(128);

                entity.Property(e => e.CgName)
                    .IsRequired()
                    .HasColumnName("CG_Name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TblIpaddress>(entity =>
            {
                entity.HasKey(e => e.IaId);

                entity.ToTable("Tbl_IPAddress");

                entity.Property(e => e.IaId)
                    .HasColumnName("IA_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IaCityId).HasColumnName("IA_CityID");

                entity.Property(e => e.IaContryId).HasColumnName("IA_ContryID");

                entity.Property(e => e.IaIp)
                    .IsRequired()
                    .HasColumnName("IA_IP")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.IaIsp)
                    .IsRequired()
                    .HasColumnName("IA_ISP")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("Tbl_Log");

                entity.Property(e => e.LogId).HasColumnName("Log_ID");

                entity.Property(e => e.LogDateTime).HasColumnName("Log_DateTime");

                entity.Property(e => e.LogRaw)
                    .IsRequired()
                    .HasColumnName("Log_Raw");
            });

            modelBuilder.Entity<TblPageVisit>(entity =>
            {
                entity.HasKey(e => e.PvId);

                entity.ToTable("Tbl_PageVisit");

                entity.Property(e => e.PvId).HasColumnName("PV_ID");

                entity.Property(e => e.PvBrowerCodeId).HasColumnName("PV_BrowerCodeID");

                entity.Property(e => e.PvBrowerInfo).HasColumnName("PV_BrowerInfo");

                entity.Property(e => e.PvDateTime).HasColumnName("PV_DateTime");

                entity.Property(e => e.PvLogId).HasColumnName("PV_LogID");

                entity.Property(e => e.PvPageUrl)
                    .IsRequired()
                    .HasColumnName("PV_PageUrl");

                entity.Property(e => e.PvPlatformCodeId).HasColumnName("PV_PlatformCodeID");

                entity.Property(e => e.PvReferrer).HasColumnName("PV_Referrer");

                entity.Property(e => e.PvUserAgent).HasColumnName("PV_UserAgent");

                entity.Property(e => e.PvVisitorId).HasColumnName("PV_VisitorID");

                entity.Property(e => e.PvWindowSize)
                    .HasColumnName("PV_WindowSize")
                    .HasMaxLength(50);

                entity.HasOne(d => d.PvBrowerCode)
                    .WithMany(p => p.TblPageVisitPvBrowerCode)
                    .HasForeignKey(d => d.PvBrowerCodeId)
                    .HasConstraintName("FK_BrowerCode");

                entity.HasOne(d => d.PvLog)
                    .WithMany(p => p.TblPageVisit)
                    .HasForeignKey(d => d.PvLogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Log");

                entity.HasOne(d => d.PvPlatformCode)
                    .WithMany(p => p.TblPageVisitPvPlatformCode)
                    .HasForeignKey(d => d.PvPlatformCodeId)
                    .HasConstraintName("FK_PlatformCode");

                entity.HasOne(d => d.PvVisitor)
                    .WithMany(p => p.TblPageVisit)
                    .HasForeignKey(d => d.PvVisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visitor");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Tbl_Role");

                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.Property(e => e.RoleDisplay)
                    .IsRequired()
                    .HasColumnName("Role_Display")
                    .HasMaxLength(128);

                entity.Property(e => e.RoleIsDelete).HasColumnName("Role_IsDelete");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("Role_Name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TblSession>(entity =>
            {
                entity.HasKey(e => e.SessionId);

                entity.ToTable("Tbl_Session");

                entity.Property(e => e.SessionId).HasColumnName("Session_ID");

                entity.Property(e => e.SessionGuid).HasColumnName("Session_Guid");

                entity.Property(e => e.SessionLastDateTime).HasColumnName("Session_LastDateTime");

                entity.Property(e => e.SessionStartDateTime).HasColumnName("Session_StartDateTime");

                entity.Property(e => e.SessionVisitorId).HasColumnName("Session_VisitorID");

                entity.HasOne(d => d.SessionVisitor)
                    .WithMany(p => p.TblSession)
                    .HasForeignKey(d => d.SessionVisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tbl_Session_Tbl_Visitor");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Tbl_User");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserCreateDate).HasColumnName("User_CreateDate");

                entity.Property(e => e.UserFamily)
                    .IsRequired()
                    .HasColumnName("User_Family")
                    .HasMaxLength(128);

                entity.Property(e => e.UserIsDelete).HasColumnName("User_IsDelete");

                entity.Property(e => e.UserMobile)
                    .IsRequired()
                    .HasColumnName("User_Mobile")
                    .HasMaxLength(128);

                entity.Property(e => e.UserModifyDate).HasColumnName("User_ModifyDate");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_Name")
                    .HasMaxLength(128);

                entity.Property(e => e.UserPasswordHash)
                    .IsRequired()
                    .HasColumnName("User_PasswordHash");

                entity.Property(e => e.UserPasswordSalt)
                    .IsRequired()
                    .HasColumnName("User_PasswordSalt");

                entity.Property(e => e.UserRoleId).HasColumnName("User_RoleID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role");
            });

            modelBuilder.Entity<TblVisitor>(entity =>
            {
                entity.HasKey(e => e.VisitorId);

                entity.ToTable("Tbl_Visitor");

                entity.Property(e => e.VisitorId).HasColumnName("Visitor_ID");

                entity.Property(e => e.VisitorCreateDateTime).HasColumnName("Visitor_CreateDateTime");

                entity.Property(e => e.VisitorIpid).HasColumnName("Visitor_IPID");

                entity.Property(e => e.VisitorTypeCodeId).HasColumnName("Visitor_TypeCodeID");

                entity.HasOne(d => d.VisitorIp)
                    .WithMany(p => p.TblVisitor)
                    .HasForeignKey(d => d.VisitorIpid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IP");

                entity.HasOne(d => d.VisitorTypeCode)
                    .WithMany(p => p.TblVisitor)
                    .HasForeignKey(d => d.VisitorTypeCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitorCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
