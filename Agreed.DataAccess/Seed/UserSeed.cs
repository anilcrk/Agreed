using Agreed.Core.Entities;
using Agreed.Core.Helpers.Cryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Seed
{
    class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                CompanyId = 1,
                Email = AES256.EncryptAndEncode("test@gmail.com"),
                Password = AES256.EncryptAndEncode("test"),
                FirstName = "test",
                LastName = "test",
                Status = true
            });
        }
    }
}
