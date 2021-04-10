using Agreed.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Users");
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.PasswordHash).HasMaxLength(500);
            builder.Property(x => x.PasswordSalt).HasMaxLength(500);
            builder.Property(x => x.Password).HasMaxLength(500);

            builder.HasOne(d => d.Company)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Company");
        }
    }
}
