using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logger.Model;

namespace Logger.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurementData>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Error>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<JobState>().Property(c => c.Id).ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<JobState> JobStates { get; set; }

        public DbSet<MeasurementData> MeasurementDatum { get; set; }

        public DbSet<Error> Error { get; set; }

        public DbSet<ProductionRecord> ProductionRecords { get; set; }

        //public DbSet<Job> Jobs { get; set; }

        //public DbSet<Image> Images { get; set; }

        //public DbSet<LeadEndPreCrimp> LeadEndPreCrimps { get; set; }

        //public DbSet<LeadEndPostCrimp> LeadEndPostCrimps { get; set; }
    }
}
