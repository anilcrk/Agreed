using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.Core.Entities
{
    public class OperationClaim
    {
        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
