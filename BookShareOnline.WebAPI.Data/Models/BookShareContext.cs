using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShareOnline.WebAPI.Data.Models
{
    public class BookShareContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source =(localdb)\MSSQLLocalDB; Initial Catalog=BookShareOnline.Data_DB; Integrated Security = True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<CartEntry> Cart { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
