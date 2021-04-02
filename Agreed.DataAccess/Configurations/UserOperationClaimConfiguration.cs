using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Configurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("UserOperationClaims");
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.HasOne(d => d.User)
                .WithMany(p => p.UserOperationClaims)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserOperationClaims_Users");

            builder.HasOne(d => d.OperationClaim)
                .WithMany(p => p.UserOperationClaims)
                .HasForeignKey(d => d.OperationClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserOperationClaims_OperationClaims");
        }
    }
}
