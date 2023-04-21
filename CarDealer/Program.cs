using CarDealer;
using CarDealer.Models;
using System.Security.Cryptography;

class program
{
    public static void Main()
    {
        double balance;
        CarDealers cardealership = new CarDealers("idek");
        Console.Clear();
        
        bool boolean = true;
        while (boolean == true)
        {
            
            Console.WriteLine(" ----------------------------------");
            Console.WriteLine("| You can chose the following:     |");
            Console.WriteLine("| 1. Show Cardealer name           |");
            Console.WriteLine("| 2. Add users to dealership       |");
            Console.WriteLine("| 3. Show all users                |");
            Console.WriteLine("| 4. Add Balance to customer       |");
            Console.WriteLine("| 5. Check customer balance        |");
            Console.WriteLine("| 6. Delete user                   |");
            Console.WriteLine("| 7. Find user by id               |");
            Console.WriteLine("| 8. Add cars to dealership        |");
            Console.WriteLine("| 9. List of cars                  |");
            Console.WriteLine("| 10. Delete car by id             |");
            Console.WriteLine("| 11. Update cars                  |");
            Console.WriteLine("| 12. Find car by id               |");
            Console.WriteLine("| 13. Buy cars                     |");
            Console.WriteLine(" ----------------------------------");
            Console.Write("Insert here: ");


            int input = Convert.ToInt32(Console.ReadLine());  
            
            string back = "\nPress enter to go back";
            switch (input)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine(cardealership.GetCarDealerName());
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("please select user type:\n 0. Costumer\n 1. Dealer");
                        PersonType type = (PersonType)Enum.Parse(typeof(PersonType), Console.ReadLine());
                            Console.Clear();
                                Console.Write("please enter your firstname: ");
                                string firstname = Console.ReadLine();
                            Console.Clear();
                                Console.Write("please enter your lastname: ");
                                string lastname = Console.ReadLine();
                    cardealership.CreatePerson(firstname, lastname, type );
                            Console.Clear();
                                Console.WriteLine($"{firstname} {lastname} {type}");
                                Console.WriteLine($"{back}");
                            Console.ReadKey();
                        Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine($"{cardealership.GetListOfPersons()}");
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Type personid :");
                    int personid = Convert.ToInt32(Console.ReadLine());
                    if (personid == null)
                    {
                        Console.WriteLine($"No person found with ID {personid}");
                    }
                    else
                    {
                    Console.Clear();
                    Console.WriteLine("How much balance do you want to add?\n insert here: ");
                    balance = Convert.ToInt32(Console.ReadLine());
                    cardealership.AddBalance(personid, balance);    
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("enter userid: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    if (personid == null)
                    {
                        Console.WriteLine($"No person found with ID {personid}");
                    }
                    else
                    {
                    Console.Clear();
                    Console.WriteLine($"balance: {cardealership.CheckBalance(personid)}");
                    Console.Write($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.Write("Enter userid: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"{cardealership.DeletePersonByID(personid)}");
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    
                 case 7:
                    Console.Clear();
                    Console.Write("Enter person ID: ");
                    int personID = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    Person person = cardealership.GetPersonByID(personID);
                    if (person == null)
                    {
                        Console.WriteLine($"No person found with ID {personID}");
                    }
                    else
                    {
                        Console.WriteLine($"Person Details:");
                        Console.WriteLine($"ID: {person.PersonID}");
                        Console.WriteLine($"First Name: {person.Firstname}");
                        Console.WriteLine($"Last Name: {person.Lastname}");
                        Console.WriteLine($"Type: {person.Type}");
                        Console.WriteLine($"Balance: {person.Balance}");
                        Console.WriteLine($"Cars Bought:");
                        foreach (var car1 in person.BoughtCars)
                        {
                            Console.WriteLine($"- {car1.Brand} {car1.Model}");
                        }
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 8:
                    Console.Clear();
                    Console.Write("Enter person ID: ");
                    int Personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    person = cardealership.GetPersonByID(Personid);
                    if (person != null && person.Type == PersonType.Dealer)
                    {
                        Console.WriteLine("Choose a car brand:");
                        Console.WriteLine("1. Skoda");
                        Console.WriteLine("2. Ford");
                        Console.WriteLine("3. Audi");
                        Console.Write("Enter your choice: ");
                        int brandChoice = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter car model: ");
                        string carName = Console.ReadLine();
                        Console.Write("Enter car price: ");
                        double carPrice = Convert.ToDouble(Console.ReadLine());
                        Car newCar = new();
                        switch ((CarBrand)brandChoice)
                        {
                            case CarBrand.Skoda:
                                newCar.Brand = CarBrand.Skoda;
                                break;
                            case CarBrand.Ford:
                                newCar.Brand = CarBrand.Ford;
                                break;
                            case CarBrand.Audi:
                                newCar.Brand = CarBrand.Audi;
                                break;
                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                        newCar.Price = carPrice; 
                        newCar.Model = carName;
                        if (newCar != null)
                        {
                            int carID = cardealership.AddCar(newCar, Personid);
                            if (carID != -1)
                            {
                                Console.WriteLine($"Car added with ID {carID}.");
                            }
                            else
                            {
                                Console.WriteLine("Car not added.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid person ID or person is not a dealer.");
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 9:
                    Console.Clear();
                    foreach (Car car2 in cardealership.GetListOfCars())
                    {
                        Console.WriteLine($"Carid: {car2.Carid}\nCarbrand: {car2.Brand}\nCar model: {car2.Model}\nCar price: {car2.Price:C}\nInstock:{car2.instock}\n ");
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 10:
                    Console.Clear();
                    Console.Write("Enter your id: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    person = cardealership.GetPersonByID(personid);
                    if (person != null && person.Type == PersonType.Dealer)
                    {
                        Console.Clear();
                        Console.Write("Enter car id: ");
                        int carid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"{cardealership.DeleteCarById(carid, personid)}");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("User either doesnt have access or doesnt exist");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                        break;
                case 11:
                    Console.Clear();
                    Console.Write("Enter your id: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    person = cardealership.GetPersonByID(personid);
                    if (person != null && person.Type == PersonType.Dealer)
                    {
                        Console.Clear();
                        Console.Write("Enter car id: ");
                        int carid = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Car updatecar = new Car();
                        Console.WriteLine("1. Skoda");
                        Console.WriteLine("2. Ford");
                        Console.WriteLine("3. Audi");
                        Console.Write("Enter your choice: ");
                        updatecar.Brand = (CarBrand)Enum.Parse(typeof(CarBrand), Console.ReadLine(), true);
                        Console.Write("Enter the updated car model: ");
                        updatecar.Model = Console.ReadLine();
                        Console.Write("Enter the updated car price: ");
                        updatecar.Price = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Is the car in stock? (true/false): ");
                        updatecar.instock = Convert.ToBoolean(Console.ReadLine());

                        string updateResult = cardealership.UpdateCar(updatecar, personid);
                        Console.WriteLine(updateResult);
                    }

                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 12:
                    Console.Clear();
                    Console.Write("Enter Car id: ");
                    int Carid = Convert.ToInt32(Console.ReadLine());
                    Car carr = cardealership.GetCarById(Carid);
                    if (carr != null)
                    {
                        Console.WriteLine($"Car ID: {carr.Carid}");
                        Console.WriteLine($"Brand: {carr.Brand}");
                        Console.WriteLine($"Model: {carr.Model}");
                        Console.WriteLine($"Price: {carr.Price}");
                        Console.WriteLine($"In Stock: {carr.instock}");
                    }
                    else
                    {
                        Console.WriteLine("Car not found");
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 13:
                    Console.Clear();
                    Console.Write("Enter car ID: ");
                    Carid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter your ID: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Car car = cardealership.GetCarById(Carid);
                    if (car == null)
                    {
                        Console.WriteLine($"Car with ID {Carid} not found.");
                        Console.ReadKey();
                        return;
                    }

                    Person person2 = cardealership.GetPersonByID(personid);

                    if (person2 == null)
                    {
                        Console.WriteLine($"Person with ID {personid} not found.");
                        Console.ReadKey();
                        return;
                    }

                    if (person2.Type != PersonType.Customer)
                    {
                        Console.WriteLine($"Person with ID {personid} is not a customer.");
                        Console.ReadKey();
                        return;
                    }

                    Customer customer = (Customer)person2;

                    if (car.instock == false)
                    {
                        Console.WriteLine($"Car with ID {Carid} is not in stock.");
                        Console.ReadKey();
                        return;
                    }
                    if (customer.Balance < car.Price)
                    {
                        Console.WriteLine("You cant buy this car");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (customer.Balance > car.Price)
                    {
                        cardealership.BuyCar(Carid, personid);
                        person2.Balance -= car.Price;
                        Console.WriteLine("Car purchased successfully.");
                        Console.ReadKey();
                    }
                    break;
            }
        }

    }
 }
