using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CustomerWebAPI.Models;

namespace CustomerWebAPI.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> customers { get; set; }
    }
}