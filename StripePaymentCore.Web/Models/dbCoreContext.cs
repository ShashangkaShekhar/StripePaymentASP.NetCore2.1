using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StripePaymentCore.Web.Models
{
    public partial class dbCoreContext : DbContext
    {
        public dbCoreContext()
        {
        }

        public dbCoreContext(DbContextOptions<dbCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserMarks> UserMarks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            // {
            //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //    optionsBuilder.UseSqlServer("Server=DESKTOP-7OJNKVF;Database=dbCore;Trusted_Connection=True;");
            // }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<UserMarks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.HasSequence<int>("RowId");
        }
    }
}
