using HelthFundData.Models;
using Microsoft.EntityFrameworkCore;

namespace HelthFundData.DbContext
{
    public class HelthFundDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public HelthFundDbContext(DbContextOptions<HelthFundDbContext> options): base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<Recovery> Recoveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Vaccine>().ToTable("Vaccines");
            modelBuilder.Entity<Recovery>().ToTable("Recovery");
            base.OnModelCreating(modelBuilder);
        }
    }
}


