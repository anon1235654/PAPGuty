using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class PremiumRating:IRatingStrategy
    {
        //public PremiumRating() { }
        //public PremiumRating(double rate, int userId, int bikeId):base(rate, userId, bikeId, true) { }
        public void SetRate(Rating rating)
        {
            rating.Rate = rating.Rate * 2;
        }
    }
}
