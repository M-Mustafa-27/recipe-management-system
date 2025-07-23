using System;
using System.Collections.Generic;
using E_Project_James_Thew.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Project_James_Thew.Data;

public partial class ChefJamesDbContext : DbContext
{
    public ChefJamesDbContext()
    {
    }

    public ChefJamesDbContext(DbContextOptions<ChefJamesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Contest> Contests { get; set; }

    public virtual DbSet<ContestParticipant> ContestParticipants { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AId).HasName("PK__ANNOUNCE__71AC6D411DB53EBB");

            entity.ToTable("ANNOUNCEMENT");

            entity.Property(e => e.AId).HasColumnName("A_ID");
            entity.Property(e => e.ADescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("A_DESCRIPTION");
            entity.Property(e => e.ATitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("A_TITLE");
        });

        modelBuilder.Entity<Contest>(entity =>
        {
            entity.HasKey(e => e.ContestId).HasName("PK__CONTESTS__BB3F236F84F64290");

            entity.ToTable("CONTESTS");

            entity.Property(e => e.ContestId).HasColumnName("CONTEST_ID");
            entity.Property(e => e.ContestDate).HasColumnName("CONTEST_DATE");
            entity.Property(e => e.ContestDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CONTEST_DESCRIPTION");
            entity.Property(e => e.ContestName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTEST_NAME");
            entity.Property(e => e.ContestTitle)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CONTEST_TITLE");
        });

        modelBuilder.Entity<ContestParticipant>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__CONTEST___A3420A77E07A3C47");

            entity.ToTable("CONTEST_PARTICIPANTS");

            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.User).WithMany(p => p.ContestParticipants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__CONTEST_P__USER___5EBF139D");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__FEEDBACK__BAEB513E56DB2B9C");

            entity.ToTable("FEEDBACKS");

            entity.Property(e => e.FeedbackId).HasColumnName("FEEDBACK_ID");
            entity.Property(e => e.FeedbackMsg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FEEDBACK_MSG");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK__FEEDBACKS__U_ID__6383C8BA");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__MEMBERSH__401962070C74ECAA");

            entity.ToTable("MEMBERSHIPS");

            entity.HasIndex(e => e.MEmail, "UQ__MEMBERSH__EA85F66484EC637B").IsUnique();

            entity.Property(e => e.MembershipId).HasColumnName("MEMBERSHIP_ID");
            entity.Property(e => e.MEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("M_EMAIL");
            entity.Property(e => e.MName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("M_NAME");
            entity.Property(e => e.MembershipPlan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MEMBERSHIP_PLAN");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK__MEMBERSHIP__U_ID__5070F446");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.RecipeId).HasName("PK__Recipes__0958CAF1952BEACE");

            entity.Property(e => e.RecipeId).HasColumnName("Recipe_id");
            entity.Property(e => e.FullRecipe).HasColumnName("Full_Recipe");
            entity.Property(e => e.RecipeCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Recipe_Category");
            entity.Property(e => e.RecipeDescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Recipe_Description");
            entity.Property(e => e.RecipeImage)
                .HasMaxLength(500)
                .HasColumnName("Recipe_Image");
            entity.Property(e => e.RecipeIngredients).HasColumnName("Recipe_Ingredients");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Recipe_Name");
            entity.Property(e => e.RecipeStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Recipe_Status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__ROLES__5AC4D222B5D5CBDD");

            entity.ToTable("ROLES");

            entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLE_NAME");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__USER_ACC__F3BEEBFF0D1F311E");

            entity.ToTable("USER_ACCOUNTS");

            entity.HasIndex(e => e.UserEmail, "UQ__USER_ACC__43CA31683C45BDDF").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("USER_ADDRESS");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_NAME");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USER_PASSWORD");

            entity.HasOne(d => d.RIdNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.RId)
                .HasConstraintName("FK__USER_ACCOU__R_ID__4CA06362");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
