using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDBTesting
{
    public class AlgoTestManager
    {
        private readonly IMockDatabase _databaseContext;

        public AlgoTestManager(IMockDatabase databaseContext)
        {
            _databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        public User CreateUser(User? user)
        {
            // Your logic for creating a user, possibly interacting with _databaseContext
            _databaseContext.AddUser(user);
            return user;
        }

        public void CreateRating(Rating? rating)
        {
            // Your logic for creating a user, possibly interacting with _databaseContext
            _databaseContext.AddRating(rating);
        }
        public void CreateBike(Bike? bike)
        {
            // Your logic for creating a user, possibly interacting with _databaseContext
            _databaseContext.AddBike(bike);
        }
        public User GetUserById(int userId)
        {
            // Your logic for retrieving a user by ID from _databaseContext
            return _databaseContext.GetUserById(userId);
        }
        public IQueryable<Rating> GetRatingList()
        {
            return _databaseContext.GetRatings();
        }

        public bool CheckUserPremium(int? id)
        {
            return _databaseContext.CheckUserPremium(id);
        }

        public double AverageCalc(IQueryable<Rating> ratings)
        {
            double sum = 0;
            foreach (Rating rate in ratings)
            {
                if (rate.UserID != null)
                {
                    if (CheckUserPremium(rate.UserID))
                    {
                        sum += (rate.Rate * 2);
                    }
                    else
                    {
                        sum += (rate.Rate * 0.5);
                    }
                }
                else
                {
                    sum += (rate.Rate * 0.5);
                }
            }
            return sum / Convert.ToDouble(ratings.ToList().Count);
        }
    }
}
