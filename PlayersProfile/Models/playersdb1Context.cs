using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlayersProfile.Models
{
    public partial class playersdb1Context :  IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public playersdb1Context()
        {
        }

        public playersdb1Context(DbContextOptions<playersdb1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Carstab> Carstab { get; set; }
        public virtual DbSet<Playerstab> Playerstab { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=den1.mssql8.gear.host;Database=playersdb1;User ID = playersdb1;Password= Ge4BA1Z-lp5?;");
            }
        }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Carstab>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Carstab)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_carstab_playerstab");
            });

            modelBuilder.Entity<Playerstab>(entity =>
            {
                entity.Property(e => e.PlayerId).ValueGeneratedNever();
            });
        }
    }
}
