using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.Core.Entities
{
    public class Company
    {
        public Company()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string CompanyName {  get; set; }
        public ICollection<User> Users { get; set; }
    }
}
