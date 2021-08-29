using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
    public class BrendConfig : IEntityTypeConfiguration<Brend>
    {
        public void Configure(EntityTypeBuilder<Brend> builder)
        {
            builder.Property(x => x.BrendName).IsRequired();
            builder.HasIndex(x => x.BrendName).IsUnique();
            
        }
    }
}
