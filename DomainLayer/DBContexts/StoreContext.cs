using System;
using System.Collections.Generic;
using System.Text;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.DBContexts
{
    public class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=BookStore;Trusted_Connection=True;");
            }
        }
    }
}
