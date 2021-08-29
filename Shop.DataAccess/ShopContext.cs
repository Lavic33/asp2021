using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Configurations;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess
{
   public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-67CBU7E\\SQLEXPRESS;Initial Catalog=ShopASP;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrendConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new MailConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderStatusConfig());
            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });
        }

        public DbSet<Brend> Brends { get; set; }
        public DbSet<Brend> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Log> Logs { get; set; }



        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
