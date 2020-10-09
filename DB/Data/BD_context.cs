using BD_GIBDD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Data
{
    public class BD_context: DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<BrandAuto> BrandAutos { get; set; }
        public DbSet<CarsStolen> CarsStolens { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarsStolen>((cs =>
            {
                cs.HasNoKey();
            }));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=GIBDD");
        }
    }
}
