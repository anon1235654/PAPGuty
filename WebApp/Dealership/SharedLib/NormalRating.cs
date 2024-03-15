using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityClasses
{
    public class NormalRating:IRatingStrategy
    {
        //public NormalRating(double rate, int userId, int bikeId);
            public void SetRate(Rating rating)
            {
                rating.Rate = rating.Rate * 0.5;
            }
    }
}
