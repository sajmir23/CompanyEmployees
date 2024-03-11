using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryContext: DbContext
    {
      public RepositoryContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

       public DbSet<Company>? Companies { get; set; }

       public DbSet<Employee>? Employees { get; set; }

        public DbSet<Review>? Review { get; set; }

        public DbSet<House>? House { get; set; }

        public DbSet<Car>? Cars { get; set; }   

    }
}


