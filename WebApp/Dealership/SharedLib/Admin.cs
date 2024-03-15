using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class Admin: User
    {
        public Admin() { }

        public Admin(int id, string name, string email):base(id, name, email) { }
        
        public Admin(string email, string password): base(email, password) { }  

        public override string ToString()
        {
            return $"{this.Id}, {this.Name}";
        }
    }
}
