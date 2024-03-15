using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EntityClasses;
namespace AdminClasses
{
    public class BikeManager:IBikeManager
    {
        public BikeManager() { }

        public List<Bike> GetBikes()
        {
            List<Bike> bikes = BikeDBHelper.GetBikes();

            if(bikes != null)
            {
                return bikes;
            }
            else { return null; }
        }

        public Bike GetBike(int? id)
        {
            return BikeDBHelper.GetBike(id);
        }
        public void AddBike(Bike bike) 
        {
            BikeDBHelper.AddBike(bike);
        }

        public bool DeleteBike(int id) 
        {
            if (BikeDBHelper.DeleteBike(id))
            {
                return true;
            }
            else { return false; }
        }
        public bool UpdateBikeModel(Bike bike, string model) { return BikeDBHelper.UpdateBikeModel(bike, model); }
        public bool UpdateBikeBrand(Bike bike, string brand) { return BikeDBHelper.UpdateBikeBrand(bike, brand); }
        public bool UpdateBikePrice(Bike bike, double price) { return BikeDBHelper.UpdateBikePrice(bike, price); }
        public bool UpdateBikeImage(Bike bike, string imageUrl) { return BikeDBHelper.UpdateBikeImageURL(bike, imageUrl); }
    }
}
