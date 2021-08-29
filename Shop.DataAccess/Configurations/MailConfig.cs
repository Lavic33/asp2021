using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Configurations
{
   public class MailConfig : IEntityTypeConfiguration<SentEmails>
    {
        public void Configure(EntityTypeBuilder<SentEmails> builder)
        {
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Subject).IsRequired();
            builder.Property(x => x.From).IsRequired();
            builder.Property(x => x.To).IsRequired();

        }
    }
}
