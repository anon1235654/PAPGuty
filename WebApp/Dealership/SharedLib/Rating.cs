
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class Rating
    {
        private double _rate;
        private int? _userId;
        private int _bikeId;
        

        public double Rate { get { return _rate; } set { this._rate = value; } }
        public int? UserID { get { return _userId; } set { this._userId = value; } }
        public int BikeID { get { return _bikeId; } set { this._bikeId = value; } }
       

        public Rating(double rate, int? userId, int bikeId) 
        {
            _rate = rate;
            _userId = userId;
            _bikeId = bikeId;
        }

    }
}
