using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityClasses;
namespace AdminClasses
{
    public interface IBikeManager
    {
        List<Bike> GetBikes();
        void AddBike(Bike bike);
        Bike GetBike(int? id);
        bool DeleteBike(int id);
        bool UpdateBikeModel(Bike bike, string model);
        bool UpdateBikeBrand(Bike bike, string brand);
        bool UpdateBikePrice(Bike bike, double price);
        bool UpdateBikeImage(Bike bike, string imageUrl);

    }
}
