using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Configurations
{
    public class CompantConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Companies");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CompanyName).HasMaxLength(100);
        }
    }
}
