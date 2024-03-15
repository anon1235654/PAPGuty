using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EntityClasses;
namespace AdminClasses
{
    public static class Algorythm
    {
        private static IRatingStrategy _strategy;
        private static IUserManager _userManager = new UserManager();
        private static void SetStrategy(IRatingStrategy strategy) 
        { 
            _strategy = strategy;
        }

        public static double AverageCalc(List<Rating> rates) 
        { 
            double sum = 0;
            try
            {
                foreach (Rating rate in rates)
                {
                    if (rate.UserID != null)
                    {
                        if (_userManager.CheckPremium(rate.UserID))
                        {
                            SetStrategy(new PremiumRating());
                            _strategy.SetRate(rate);
                            sum += rate.Rate;
                        }
                        else
                        {
                            SetStrategy(new NormalRating());
                            _strategy.SetRate(rate);
                            sum += rate.Rate;
                        }
                    }
                    else
                    {
                        SetStrategy(new NormalRating());
                        _strategy.SetRate(rate);
                        sum += rate.Rate;
                    }
                }
                return sum / rates.Count;
            }catch (DivideByZeroException ex) 
            {
                return 0;
            }
        }

        private static char[] GenerateCharArray() 
        {
            const int numberOfLetters = 26; 
            const int numberOfNumbers = 10; 
            // Generating an array with all lowercase alphabet, uppercase alphabet, and numbers
            char[] charArray = new char[numberOfLetters * 2 + numberOfNumbers];

            // Adding lowercase alphabet
            for (int i = 0; i < numberOfLetters; i++) // O(26)linear // const 
            {
                charArray[i] = (char)('a' + i);
            }

            // Adding uppercase alphabet
            for (int i = 0; i < numberOfLetters; i++)
            {
                charArray[i + numberOfLetters] = (char)('A' + i);
            }

            // Adding numbers
            for (int i = 0; i < numberOfNumbers; i++)
            {
                charArray[i + numberOfLetters * 2] = (char)('0' + i);
            }

            return charArray;
        }
        public static string GenerateString(int length)
        {
            string password = "";
            Random random = new Random();
            char[] charsArray = GenerateCharArray();
            
            
            for (int i = 0; i < length; i++) //put this as parameter for the admin to choose TODO
            {
                password += charsArray[random.Next(charsArray.Length)].ToString();
            }
            return password;
        }
    }
}

