using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityClasses
{
    //Defines the table name here
    public class User
    {
        public User() { }
        public User(int id, string name, string email, bool isPremium) 
        {
            Id = id;
            Name = name;
            Email = email;
            IsPremium = isPremium;
        }
        public User(int id, string name, string email, bool isAdmin, bool isPremium)
        {
            Id = id;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
            IsPremium = isPremium;
        }
        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            
        }
        public User(string email, string name, string password)
        {
            Password = password;
            Name = name;
            Email = email;
        }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public User(string email, string name, string password, bool isPremium)
        {
            Email = email;
            Name = name;
            Password = password;
            IsPremium = isPremium;
        }
        [Key]
        public int Id { get; set; }

        // Apply The Required on the specific form handlers, otherwise the Required Constraint here will Bubble Up        
        [Required(ErrorMessage = "Enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
        public bool IsAdmin { get; }
        public bool IsPremium { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
