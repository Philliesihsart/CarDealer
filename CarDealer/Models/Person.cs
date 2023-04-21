using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    abstract class Person
    {
        public int PersonID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public PersonType Type { get; set; }
        public double Balance { get; set; }
        public List<Car> BoughtCars { get; set; }
    }
}
