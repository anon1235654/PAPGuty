using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityClasses
{
    public class Customer : User
    {
        
        public Customer() { }
        public Customer(int id, string name, string email, bool isAdmin) : base(id, name, email)
        {
            IsAdmin = isAdmin;
        }
        public Customer(int id, string name, string email, bool isAdmin, bool isPremium) : base(id, name, email, isAdmin, isPremium)
        {
            
        }
        public bool IsAdmin { get; set; }
        public override string ToString()
        {
            return $"{this.Id}, {this.Name}, {this.Email}";
        }
    }
}
