using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectTeamFour_Backend.Models;

#nullable disable

namespace ProjectTeamFour_Backend.Context
{
    public partial class CarCarPlanContext : DbContext
    {
        public CarCarPlanContext()
        {
        }

        public CarCarPlanContext(DbContextOptions<CarCarPlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Backendmember> Backendmembers { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<DraftPlan> DraftPlans { get; set; }
        public virtual DbSet<DraftProject> DraftProjects { get; set; }
        public virtual DbSet<FbloginMember> FbloginMembers { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=a108342002.database.windows.net;Database=CarCarPlan;User=a108342002;Password=Mycarcarplan4;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.EditTime).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_dbo.Announcements_dbo.Members_MemberId");
            });

            modelBuilder.Entity<Backendmember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_dbo.Backendmembers");

                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");

                entity.Property(e => e.MemberBirth).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.HasIndex(e => e.ProjectId, "IX_ProjectId");

                entity.Property(e => e.CommentAnswer).HasColumnName("Comment_Answer");

                entity.Property(e => e.CommentQuestion).HasColumnName("Comment_Question");

                entity.Property(e => e.CommentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Comment_Time");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_dbo.Comments_dbo.Members_MemberId");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_dbo.Comments_dbo.Projects_ProjectId");
            });

            modelBuilder.Entity<DraftPlan>(entity =>
            {
                entity.HasIndex(e => e.DraftProjectId, "IX_DraftProjectId");

                entity.Property(e => e.DraftPlanPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DraftPlanShipDate).HasColumnType("datetime");

                entity.HasOne(d => d.DraftProject)
                    .WithMany(p => p.DraftPlans)
                    .HasForeignKey(d => d.DraftProjectId)
                    .HasConstraintName("FK_dbo.DraftPlans_dbo.DraftProjects_DraftProjectId");
            });

            modelBuilder.Entity<DraftProject>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.Property(e => e.AmountThreshold).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DraftCreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DraftFundingAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DraftLastEditTime).HasColumnType("datetime");

                entity.Property(e => e.DraftProjectAnswer).HasColumnName("DraftProject_Answer");

                entity.Property(e => e.DraftProjectQuestion).HasColumnName("DraftProject_Question");

                entity.Property(e => e.DraftSubmittedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FundingAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.DraftProjects)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_dbo.DraftProjects_dbo.Members_MemberId");
            });

            modelBuilder.Entity<FbloginMember>(entity =>
            {
                entity.HasKey(e => e.FbmemberId)
                    .HasName("PK_dbo.FBLoginMembers");

                entity.ToTable("FBLoginMembers");

                entity.HasIndex(e => e.FbmemberId, "IX_FBMemberId");

                entity.Property(e => e.FbmemberId)
                    .ValueGeneratedNever()
                    .HasColumnName("FBMemberId");

                entity.Property(e => e.GetMemberBirth).HasColumnType("datetime");

                entity.HasOne(d => d.Fbmember)
                    .WithOne(p => p.FbloginMember)
                    .HasForeignKey<FbloginMember>(d => d.FbmemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.FBLoginMembers_dbo.Members_FBMemberId");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.Property(e => e.MemberBirth).HasColumnType("datetime");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.MemberId, "IX_MemberId");

                entity.HasIndex(e => e.PlanPlanId, "IX_Plan_PlanId");

                entity.Property(e => e.Condition).HasColumnName("condition");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderTotalAccount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanPlanId).HasColumnName("Plan_PlanId");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_dbo.Orders_dbo.Members_MemberId");

                entity.HasOne(d => d.PlanPlan)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PlanPlanId)
                    .HasConstraintName("FK_dbo.Orders_dbo.Plans_Plan_PlanId");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_OrderId");

                entity.HasIndex(e => e.PlanId, "IX_PlanId");

                entity.Property(e => e.Condition).HasColumnName("condition");

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanShipDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Orders_OrderId");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("FK_dbo.OrderDetails_dbo.Plans_PlanId");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasIndex(e => e.ProjectId, "IX_ProjectId");

                entity.Property(e => e.PlanPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PlanShipDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_dbo.Plans_dbo.Projects_ProjectId");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.ProjectId, "IX_ProjectId");

                entity.Property(e => e.AmountThreshold).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FundingAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.LastEditTime).HasColumnType("datetime");

                entity.Property(e => e.ProjectAnswer).HasColumnName("Project_Answer");

                entity.Property(e => e.ProjectQuestion).HasColumnName("Project_Question");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.SubmittedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
