using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    internal class Dealer : Person
    {

        public Dealer(int personID, string firstname, string lastname)
        {
            this.PersonID = personID;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Balance = 0;
            this.BoughtCars = new List<Car>();
            this.Type = PersonType.Dealer;
        }
    }
}
