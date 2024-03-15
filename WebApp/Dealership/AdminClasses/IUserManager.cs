using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace AdminClasses
{
    public interface IUserManager
    {
        bool RegisterUser(User user);
        User Login(User user);
        bool CheckPermissions(User user);
        bool CheckPremium(int? id);
        List<Customer> GetUsers();
        User GetUser(User user);
        User GetUser(int? id);
        Customer GetUser(string email);
        bool DeleteUser(int id);
        bool MakeUserPremium(int? id);
        bool UpdateUserEmail(int? id, string email);
        bool UpdateUserPassword(int? id, string password);
    }
}
