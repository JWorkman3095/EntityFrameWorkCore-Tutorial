using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkCore_Tutorial.Models {
    public class  AppDbContext : DbContext {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}


        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if(!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // make Cose unique
            builder.Entity<Item>(
                e => e.HasIndex(x => x.Code)
                        .IsUnique(true)
            );

        }

    }
}
