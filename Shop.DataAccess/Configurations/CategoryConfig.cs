using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Brend>
    {
        public void Configure(EntityTypeBuilder<Brend> builder)
        {
            builder.Property(x => x.CategoryName).IsRequired();
            builder.HasIndex(x => x.CategoryName).IsUnique();
            
        }
    }
}
