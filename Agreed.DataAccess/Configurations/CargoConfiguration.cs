using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Configurations
{
    public class CargoConfiguration : IEntityTypeConfiguration<Cargo>
    {

        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(d => d.Company)
                .WithMany(p => p.Cargoes)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cargoes_Company");
        }
    }
}
