using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataAccess
{
    internal static class PasswordHasher
    {
        public static byte[] PasswordSalt()
        {

            using (var saltRange = new RNGCryptoServiceProvider())
            {
                var salt = new byte[16];
                saltRange.GetBytes(salt);
                return salt;
            }
        }

        // Hash a password with a given salt
        public static byte[] HashPassword(string password, byte[] salt)
        {

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(32); // 32 bytes is a good length for storing the hash
            }
        }

        
    }
}
