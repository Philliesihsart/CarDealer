using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    internal class Car
    {
        public int Carid { get; set; }
        public CarBrand Brand { get; set; }
        public string? Model { get; set; }
        public double Price { get; set; }
        public bool instock { get; set; }
    }
}
