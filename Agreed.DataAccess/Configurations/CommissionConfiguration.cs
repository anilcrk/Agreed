using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Configurations
{
    public class CommissionConfiguration : IEntityTypeConfiguration<Commission>
    {
 
        public void Configure(EntityTypeBuilder<Commission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
