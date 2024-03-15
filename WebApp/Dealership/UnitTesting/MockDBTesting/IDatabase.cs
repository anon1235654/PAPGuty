using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDBTesting
{
    public interface IDatabase
    {
        IQueryable<User> Users { get; }
        void AddUser(User? user);
        User GetUserById(int userId);
        User GetUserByEmail(string email);
        User CheckUserEmailPassword(string email, string password);
        bool DeleteUser(int id);
    }
}
