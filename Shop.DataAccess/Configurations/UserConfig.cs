using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Adress).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.Property(x => x.Password).IsRequired();

            builder.HasMany(x => x.UserUseCases).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
