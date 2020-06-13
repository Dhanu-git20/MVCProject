using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Dal
{
    public class PatientDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H5E6UMC;Initial Catalog=PatientDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientModel>()
                .ToTable("tblPatient");
            modelBuilder.Entity<PatientModel>().HasKey(p => p.name);
        }
        public DbSet<PatientModel> PatientModels { get; set; }
    }
}
