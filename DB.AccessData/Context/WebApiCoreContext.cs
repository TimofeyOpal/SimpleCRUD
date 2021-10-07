using DB.AccessData.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DB.AccessData
{
    public class WebApiCoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CurrentWeather> Weathers { get; set; }

        public WebApiCoreContext(DbContextOptions<WebApiCoreContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
