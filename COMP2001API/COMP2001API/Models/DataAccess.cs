using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace COMP2001API.Models
{
    public partial class DataAccess : DbContext
    {
        string Connection;

        public DataAccess(DbContextOptions<DataAccess> options)
            : base(options)
        {
        }

        public virtual DbSet<PasswordsTable> PasswordsTables { get; set; }
        public virtual DbSet<SessionsTable> SessionsTables { get; set; }
        public virtual DbSet<UsersTable> UsersTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<PasswordsTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PASSWORDS_TABLE");

                entity.Property(e => e.DateOfChange)
                    .HasColumnType("date")
                    .HasColumnName("date_of_change");

                entity.Property(e => e.NewPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("new_password");

                entity.Property(e => e.PreviousPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("previous_password");

                entity.Property(e => e.UserIdNum).HasColumnName("user_ID_num");

                entity.HasOne(d => d.UserIdNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserIdNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID");
            });

            modelBuilder.Entity<SessionsTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SESSIONS_TABLE");

                entity.Property(e => e.DateOfSession)
                    .HasColumnType("date")
                    .HasColumnName("date_of_session");

                entity.Property(e => e.TimeOfSession).HasColumnName("time_of_session");

                entity.Property(e => e.UserIdNum).HasColumnName("user_ID_num");

                entity.HasOne(d => d.UserIdNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserIdNum)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_ID_Sessions");
            });

            modelBuilder.Entity<UsersTable>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__USERS_TA__B9BF33078DB946F8");

                entity.ToTable("USERS_TABLE");

                entity.Property(e => e.UserId).HasColumnName("user_ID");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("user_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public bool Validate (UsersTable user)
        {
            Database.ExecuteSqlRaw("EXEC ValidateUSER @Email, @Password",
                new SqlParameter("@Email", user.EmailAddress),
                new SqlParameter("@Password", user.UserPassword));
            return true;
        }
    }
}
