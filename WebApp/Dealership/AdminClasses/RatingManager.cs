using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EntityClasses;
namespace AdminClasses
{
    public class RatingManager:IRatingManager
    {
        

        public RatingManager() { }
        
        
        public bool AddRating(Rating rating)
        {
            
            return RatingDBHelper.AddRating(rating);
        }

        public bool CheckExistenceRating(Rating rating)
        {
            return RatingDBHelper.CheckExistenceRating(rating);
        }
        public bool UpdateRating(Rating rating) 
        { 
            return RatingDBHelper.UpdateRating(rating);
        }


        public Dictionary<int, double> GetRatingList()
        {
            Dictionary<int, double> RatePerBike = new Dictionary<int, double>();
            
            foreach (Bike bike in BikeDBHelper.GetBikes()) 
            {
                RatePerBike.Add(bike.Id, Algorythm.AverageCalc(RatingDBHelper.GetRatingsperBike(bike.Id)));         
            }
            return RatePerBike;
        }
    }
}
