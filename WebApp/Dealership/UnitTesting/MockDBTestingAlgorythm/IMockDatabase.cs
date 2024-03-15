using EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.MockDBTesting
{
    public interface IMockDatabase
    {
        IQueryable<User> Users { get; }
        IQueryable<Rating> Ratings { get; }
        IQueryable<Bike> Bikes { get; }
        void AddUser(User? user);
        void AddRating(Rating? rate);
        void AddBike(Bike? bike);
        User GetUserById(int userId);
        bool CheckUserPremium(int? id);
        IQueryable<Rating> GetRatings();
    }
}
