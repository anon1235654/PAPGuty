using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class UserSettings
    {
        private string _prefBrand;
        private double _minPrice;
        private double _maxPrice;

        public UserSettings() { }
        public UserSettings(string prefBrand, double minPrice, double maxPrice)
        {
            _prefBrand = prefBrand;
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }

        public string PrefBrand { get { return _prefBrand; } set { _prefBrand = value; } }
        public double MinPrice { get { return _minPrice; } set { _minPrice = value; } }
        public double MaxPrice { get { return _maxPrice; } set { _maxPrice = value; } }

    }
}
