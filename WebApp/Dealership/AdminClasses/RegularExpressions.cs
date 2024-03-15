using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdminClasses
{
    public static class RegularExpressions
    {
        public static bool CheckCredentials(string email, string password)
        {
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            Regex emailRegex = new Regex(emailPattern);
            string passwordPattern = @"\b[A-Za-z0-9]{8,}\b";
            Regex passwordRegex = new Regex(passwordPattern);

            if(email == null || password == null)
            {
                return false;
            }
            bool validate = emailRegex.IsMatch(email) && passwordRegex.IsMatch(password);
            return validate;
        }
        public static bool CheckPassword(string password)
        {
            
            string passwordPattern = @"\b[A-Za-z0-9]{8,}\b";
            Regex passwordRegex = new Regex(passwordPattern);

            if (password == null)
            {
                return false;
            }
            bool validate = passwordRegex.IsMatch(password);
            return validate;
        }
        public static bool CheckEmail(string email)
        {
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
            Regex emailRegex = new Regex(emailPattern);
            

            if (email == null)
            {
                return false;
            }
            bool validate = emailRegex.IsMatch(email);
            return validate;
        }
    }
}
