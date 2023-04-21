using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer
{
    internal class CarDealers
    {
        public List<Car> Cars = new List<Car>();
        List<Person> Persons = new List<Person>();
        List<Car> boughtcars = new List<Car>();
        string _companyname;
        int id;
        int carid;
        public CarDealers(string CompanyName)
        {
            Persons = new List<Person>();
            Cars = new List<Car>();
            boughtcars = new List<Car>();
            _companyname = CompanyName;
            id = 0;
            carid = 0;
            void loadcars()
            {
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Ford, Model = "Mustang", Price = 2500000, instock = true });
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Ford, Model = "Shelby", Price = 3500000, instock = true });
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Audi, Model = "Q8RS", Price = 2740000, instock = true });
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Audi, Model = "RS7", Price = 3400000, instock = true });
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Skoda, Model = "Octavia", Price = 750000, instock = true });
            Cars.Add(new Car { Carid = ++carid, Brand = CarBrand.Skoda, Model = "Octavia RS", Price = 1250000, instock = true });
            }
            loadcars();
        }
        public string GetCarDealerName()
        {
            string CompanyName = "Idek";
            return CompanyName;
        }

        public int CreatePerson(string firstname, string lastname, PersonType type)
        {
            Person newPerson;


            switch (type)
            {
                case PersonType.Customer:
                    newPerson = new Customer(++id, firstname, lastname);
                    break;
                case PersonType.Dealer:
                    newPerson = new Dealer(++id, firstname, lastname);
                    break;
                default:
                    throw new ArgumentException($"Invalid person type: {type}");
            }
            Persons.Add(newPerson);

            return newPerson.PersonID;
        }



        public string DeletePersonByID(int personid)
        {
            id = personid;
            Persons.Remove(Persons.Find(x => x.PersonID == id));
            string message = "User has been deleted";
            return message;
        }

        public string AddBalance(int personid, double balance)
        {
            Persons.Find(x => x.PersonID == personid).Balance += balance;
            return balance.ToString();
        }

        public double CheckBalance(int personid)
        {
            return Persons.Find(x => x.PersonID == personid).Balance;
        }

        public Person GetPersonByID(int personid)
        {
            return Persons.FirstOrDefault(p => p.PersonID == personid);
        }

        public string GetListOfPersons()
        {
            string result = "";
            foreach (Person person in Persons)
            {
                string boughtCars = "";
                foreach (var car in person.BoughtCars)
                {
                    boughtCars += car.Model + ", ";
                    
                }
                result += $"PersonID: {person.PersonID}\nFirstname: {person.Firstname}\nLastname: {person.Lastname}\nType: {person.Type}\nBalance: {person.Balance}\nBoughtcars: {boughtCars}\n\n";
            }
            return result;
        }

        public int AddCar(Car newCar, int personid)
        {
            Person person = Persons.FirstOrDefault(p => p.PersonID == personid);
            if (person != null && person.Type == PersonType.Dealer)
            {
                newCar.Carid = ++carid;
                Cars.Add(newCar);
                return newCar.Carid;
            }
            else
            {
                return -1;
            }
        }


        public string DeleteCarById(int carid, int personid)
        {
            Person person = Persons.FirstOrDefault(p => p.PersonID == personid);
            if (person != null && person.Type == PersonType.Dealer)
            {
                Car car = Cars.FirstOrDefault(x => x.Carid == carid);
                if (car == null)
                {
                    Console.WriteLine("car doesnt exist");
                }
                Cars.Remove(Cars.Find(x => x.Carid == carid));
            }
            string message = "Car has been deleted";
            return message;
        }
        public string UpdateCar(Car updatecar, int personid)
        {
            Person person = Persons.FirstOrDefault(x => x.PersonID == personid && x.Type == PersonType.Dealer);

            if (person == null)
            {
                Console.WriteLine("User doesnt exist");
            }

            Car car = Cars.FirstOrDefault(x => x.Carid == updatecar.Carid);

            if (car == null)
            {
                Console.WriteLine("Car doesnt exist");
            }
            car.Model = updatecar.Model;
            car.Price = updatecar.Price;
            car.instock = updatecar.instock;
            car.Brand = updatecar.Brand;

            return "car updated succesfully";
        }

        public Car GetCarById(int carid)
        {
            return Cars.FirstOrDefault(c => c.Carid == carid);
        }
        public List<Car> GetListOfCars()
        {
            List<Car> carList = new List<Car>();
            foreach (Car cars in Cars)
            {
                carList.Add(cars);
            }
            return carList;

        }
        public string BuyCar(int carid, int personid)
        {
            var car = Cars.FirstOrDefault(c => c.Carid == carid);
            var person = GetPersonByID(personid);
            if (car == null)
            {
                return "Car not found.";
            }
            if (person == null)
            {
                return "Person not found.";
            }
            if (person.Type != PersonType.Customer)
            {
                return "Only customers can buy cars.";
            }
            if (!car.instock)
            {
                return "Car is not in stock.";
            }
           
            person.BoughtCars.Add(car);
            car.instock = false;
            Cars.Remove(car);

            return $"{car.Brand} {car.Model} bought by {person.Firstname} {person.Lastname}.";
        }


    }
}
