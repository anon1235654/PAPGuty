using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EntityClasses;

namespace AdminClasses
{
    public class UserManager: IUserManager
    {
        private List<Customer> _users = new List<Customer>();
        public UserManager() { }

        public bool RegisterUser(User user)
        {
            if (UserDBHelper.RegisterUser(user))
            {
                return true;
            }
            else { return false; }
        }

        public User Login(User user) 
        {
            User userToRetrieve = null;
            User check = UserDBHelper.GetUser(user);
            if(check != null)
            {
                userToRetrieve = check;
                return userToRetrieve;
            }else { return userToRetrieve; }
        }


        public bool CheckPermissions(User user) 
        {
            return UserDBHelper.CheckPermissions(user);
        }
        public bool CheckPremium(int? id)
        {
            return UserDBHelper.CheckPremium(id);
        }
        public List<Customer> GetUsers()
        {
            this._users = UserDBHelper.GetUsers();

            if(_users != null) { 
            return _users;
            }
            else
            {
                return null;
            }
        }

        public User GetUser(User user)
        {
            return UserDBHelper.GetUser(user);
        }
        public User GetUser(int? id)
        {
            return UserDBHelper.GetUser(id);
        }
        public Customer GetUser(string email)
        {
            foreach (Customer customer in GetUsers())
            {
                if(customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }
        public bool DeleteUser(int id)
        {
            if (UserDBHelper.DeleteUser(id)) {  return true; }
            return false;
        }
        public bool MakeUserPremium(int? id)
        {
            return UserDBHelper.MakeUserPremium(id);
        }

        public bool UpdateUserEmail(int? id, string email)
        {
            return UserDBHelper.UpdateUserEmail(id, email);
        }

        public bool UpdateUserPassword(int? id, string password)
        {
            return UserDBHelper.UpdateUserPassword(id, password);
        }
    }
}
