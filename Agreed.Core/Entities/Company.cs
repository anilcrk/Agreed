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
        public ICollection<Cargo> Cargoes{ get; set; }
        public ICollection<Commission> Commissions{ get; set; }
        public ICollection<Order> Orders{ get; set; }
    }
}
