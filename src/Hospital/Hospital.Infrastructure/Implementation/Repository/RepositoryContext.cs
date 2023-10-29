using Hospital.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Implementation.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Address> Address { get; set; }
        public DbSet<Hospitals> Hospital { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Staff> Staff { get; set; }

    }
}
