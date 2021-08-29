using Microsoft.EntityFrameworkCore;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
   public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName).IsRequired();
            builder.HasIndex(x => x.ProductName).IsUnique();
            builder.Property(x => x.Description).IsRequired();
            builder.HasIndex(x => x.Description).IsUnique();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.CategoryId).IsRequired();


            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Brend).WithMany().HasForeignKey(x => x.BrendId).OnDelete(DeleteBehavior.Restrict);






        }
    }
}
