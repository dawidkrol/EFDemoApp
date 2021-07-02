using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        //public PeopleContext(DbContextOptions options) : base(options)
        //{

        //}
        public DbSet<PersonBase> People { get; set; }
        public DbSet<Person> PeopleEx { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAdressess { get; set; }
        public DbSet<WorkDone> WorkDone { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EFDemoDB;User ID=sa;Password=zaq1@WSX");
        }
    }
}
