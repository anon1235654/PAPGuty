using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;

namespace AdminClasses
{
    public interface IRatingManager
    {
        bool AddRating(Rating rating);
        bool UpdateRating(Rating rating);
        bool CheckExistenceRating(Rating rating);
        Dictionary<int, double> GetRatingList();
    }
}
