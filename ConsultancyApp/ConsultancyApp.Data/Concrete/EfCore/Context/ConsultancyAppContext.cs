using ConsultancyApp.Data.Concrete.EfCore.Config;
using ConsultancyApp.Data.Concrete.EfCore.Extensions;
using ConsultancyApp.Entity.Concrete;
using ConsultancyApp.Entity.Concrete.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Context
{
    public class ConsultancyAppContext : IdentityDbContext<User, Role, string>
    {
        public ConsultancyAppContext(DbContextOptions options) : base(options)
        {

        }   
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CategoryDescription> CategoryDescription { get; set; }
        public DbSet<Psychologist> Psychologist { get; set; }
        public DbSet<PsychologistCategory> PsychologistCategory { get; set; }
        public DbSet<PsychologistCustomer> PsychologistCustomer { get; set; }
        public DbSet<PsychologistDescription> PsychologistDescription { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<RequestCategory> RequestCategory { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfig).Assembly); //
            base.OnModelCreating(modelBuilder);
        }
    }

}
