using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
    public class OrderStatusConfig : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.Property(x => x.OrderStatusName).IsRequired();
            builder.HasIndex(x => x.OrderStatusName).IsUnique();
            
        }
    }
}
