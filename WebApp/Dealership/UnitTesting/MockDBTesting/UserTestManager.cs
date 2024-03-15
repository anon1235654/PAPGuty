using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDBTesting
{
    public class UserTestManager
    {
        private readonly IDatabase _databaseContext;

        public UserTestManager(IDatabase databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public User CreateUser(User? user)
        {
            // Your logic for creating a user, possibly interacting with _databaseContext
            _databaseContext.AddUser(user);
            return user;
        }

        public User GetUserById(int userId)
        {
            // Your logic for retrieving a user by ID from _databaseContext
            return _databaseContext.GetUserById(userId);
        }
        public User GetUserByEmail(string email)
        {
            // Your logic for retrieving a user by ID from _databaseContext
            return _databaseContext.GetUserByEmail(email);
        }

        public User CheckUserEmailPassword(string email, string password)
        {
            return _databaseContext.CheckUserEmailPassword(email, password);
        }

        public bool DeleteUser(int id)
        {
            return _databaseContext.DeleteUser(id);
        }
    }
}
