using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public class Bike
    {        
        public Bike(int id, string model, string brand, string addedBy, string image, double price) //image is the url
        {
            Id = id;
            Model = model.Trim();
            Brand = brand.Trim();
            Image = image;
            AddedBy = addedBy.Trim();
            Price = price;
        }
        public Bike(string model, string brand, string addedBy, string image, double price) //image is the url
        {
            Model = model.Trim();
            Brand = brand.Trim();
            Image = image;
            AddedBy = addedBy.Trim();
            Price = price;
        }
        public Bike(string model, string brand, string addedBy, double price) 
        {
            Model = model.Trim();
            Brand = brand.Trim();
            Image = null;
            AddedBy = addedBy.Trim();
            Price = price;
        }
        public Bike(int id, string model, string brand, string addedBy, double price)
        {
            Model = model.Trim();
            Brand = brand.Trim();
            Id = id;
            AddedBy = addedBy.Trim();
            Date = DateTime.Now;
            Price = price;
        }

        public int Id { get; set; }
        public string Brand{ get; set; }
        public string Model { get; set; }
        public string? Image { get; set; }
        public string AddedBy { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Brand} {Model} {Image}";
        }
    }
}
