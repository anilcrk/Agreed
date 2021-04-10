using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.Core.Entities
{
    public class User
    {
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
