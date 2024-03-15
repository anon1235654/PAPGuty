using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
using UnitTesting.MockDBTesting;

namespace UnitTesting.MockDBTestingAlgo
{
    public class InMemoryMockDBAlgo: IMockDatabase
    {
        private readonly List<User> _users = new List<User>();
        private readonly List<Rating> _ratings = new List<Rating>();
        private readonly List<Bike> _bikes = new List<Bike>();

        public IQueryable<User> Users => _users.AsQueryable(); //This "transforms" the list into a matrix that can be queryable
        public IQueryable<Rating> Ratings => _ratings.AsQueryable();
        public IQueryable<Bike> Bikes=> _bikes.AsQueryable();
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
        public void AddRating(Rating? rating)
        {
            if (rating == null)
            {
                throw new ArgumentNullException(nameof(rating));
            }
            _ratings.Add(rating);
        }


        public void AddBike(Bike? bike)
        {
            if (bike == null)
            {
                throw new ArgumentNullException(nameof(bike));
            }

            bike.Id = _bikes.Count + 1; // Simulate auto-increment
            _bikes.Add(bike);
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
        

        public bool CheckUserPremium(int? id)
        {
            User user = _users.FirstOrDefault(u =>u.Id == id);

            if(user == null )
            {
                throw new Exception(message: "User with that E-mail and Password combination doesn't exist.");
            }
            else { return user.IsPremium; };
        }

        public IQueryable<Rating> GetRatings()
        {
            return Ratings;
        }
    }
}
