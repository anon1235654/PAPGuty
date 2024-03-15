using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;

namespace UnitTesting.MockDBTesting
{
    public class InMemoryMockDB:IDatabase
    {
        private readonly List<User> _users = new List<User>();

        public IQueryable<User> Users => _users.AsQueryable(); //This "transforms" the list into a matrix that can be queryable

        public void AddUser(User? user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (user.Email.Trim() == string.Empty || user.Name.Trim() == string.Empty || user.Password.Trim() == string.Empty) 
            {
                throw new Exception(message: "Empty field.");
            }

            user.Id = _users.Count + 1; // Simulate auto-increment
            _users.Add(user);
        }
        public User GetUserById(int userId)
        {
            User user = _users.FirstOrDefault(u => u.Id == userId);

            if(user == null)
            {
                throw new ArgumentOutOfRangeException("Inexistent User.", "User does not exist.");
            }
            else { return user; }
        }
        public User GetUserByEmail(string email)
        {
            User user = _users.FirstOrDefault(u => u.Email == email);

            if(user == null)
            {
                throw new Exception(message: "User with that E-mail doesn't exist.");
            }else { return user; }
        }

        public User CheckUserEmailPassword(string email, string password)
        {
            User user = _users.FirstOrDefault(u =>u.Email == email && u.Password == password);

            if(user == null )
            {
                throw new Exception(message: "User with that E-mail and Password combination doesn't exist.");
            }
            else { return user; };
        }

        public bool DeleteUser(int id)
        {
            User user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new Exception(message: "User not Found.");
            }

            _users.Remove(user);
            return true;
            
        }
    }
}
