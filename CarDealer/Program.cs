using CarDealer;
using CarDealer.Models;
using System.Security.Cryptography;

class program
{
    public static void Main()
    {
        double balance;
        CarDealers cardealership = new CarDealers("DealerShip");
        Console.Clear();
        string back = "\nPress enter to go back";

        bool boolean = true;
        while (boolean == true)
        {
            Console.WriteLine(" ----------------------------------");
            Console.WriteLine("| You can chose the following:     |");
            Console.WriteLine("| q. Show Cardealer name           |");
            Console.WriteLine("| w. Add users to dealership       |");
            Console.WriteLine("| e. Show all users                |");
            Console.WriteLine("| r. Add Balance to customer       |");
            Console.WriteLine("| t. Check customer balance        |");
            Console.WriteLine("| y. Delete user                   |");
            Console.WriteLine("| u. Find user by id               |");
            Console.WriteLine("| i. Add cars to dealership        |");
            Console.WriteLine("| o. List of cars                  |");
            Console.WriteLine("| p. Delete car by id              |");
            Console.WriteLine("| a. Update cars                   |");
            Console.WriteLine("| s. Find car by id                |");
            Console.WriteLine("| d. Buy cars                      |");
            Console.WriteLine("| x. Exit                          |");
            Console.WriteLine(" ----------------------------------");
            Console.WriteLine("Has to be lowercase!!!");
            Console.Write($"Insert here: ");

            string ?input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                Console.WriteLine("Case doesnt exist");
                Console.WriteLine($"{back}");
                Console.ReadKey();
                Console.Clear();
            }
            Console.Clear();
            switch (input)
            {
                case "q":
                    Console.Clear();
                    Console.WriteLine(cardealership.GetCarDealerName());
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "w":
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
                case "e":
                    Console.Clear();
                    Console.WriteLine($"{cardealership.GetListOfPersons()}");
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "r":
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
                    Console.Write("How much balance do you want to add?\ninsert here: ");
                    balance = Convert.ToInt64(Console.ReadLine());
                    cardealership.AddBalance(personid, balance);
                        Console.WriteLine($"Balance added to person: {personid}");
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case "t":
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
                case "y":
                    Console.Clear();
                    Console.Write("Enter userid: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"{cardealership.DeletePersonByID(personid)}");
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    
                 case "u":
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
                case "i":
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
                case "o":
                    Console.Clear();
                    foreach (Car car2 in cardealership.GetListOfCars())
                    {
                        Console.WriteLine($"\nCarid: {car2.Carid} | Carbrand: {car2.Brand} | Car model: {car2.Model}  | Car price: {car2.Price}  | InstocK: {car2.instock}");
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "p":
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
                case "a":
                    Car updatecar = new Car();
                    Console.Clear();
                    Console.Write("Enter your id: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    person = cardealership.GetPersonByID(personid);
                    if (person != null && person.Type == PersonType.Dealer)
                    {
                        Console.Clear();
                        Console.Write("Enter car id: ");
                        updatecar.Carid = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
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
                        Console.Clear();
                    }
                    else if (person != null && person.Type == PersonType.Customer)
                    {
                        Console.WriteLine("Only Dealers can update cars!");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (person == null)
                    {
                        Console.WriteLine("User doesnt exist");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "s":
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
                        Console.Clear();
                    }
                    Console.WriteLine($"{back}");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "d":
                    Console.Clear();
                    Console.Write("Enter car ID: ");
                    Carid = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter your ID: ");
                    personid = Convert.ToInt32(Console.ReadLine());
                    Car car = cardealership.GetCarById(Carid);
                    if (car == null)
                    {
                        Console.WriteLine($"Car with ID {Carid} not found.");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    Person person2 = cardealership.GetPersonByID(personid);

                    if (person2 == null)
                    {
                        Console.WriteLine($"Person with ID {personid} not found.");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    if (person2.Type != PersonType.Customer)
                    {
                        Console.WriteLine($"Person with ID {personid} is not a customer.");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    Customer customer = (Customer)person2;

                    if (car.instock == false)
                    {
                        Console.WriteLine($"Car with ID {Carid} is not in stock.");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    if (customer.Balance < car.Price)
                    {
                        Console.WriteLine("Insuffiencient funds");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (customer.Balance > car.Price)
                    {
                        cardealership.BuyCar(Carid, personid);
                        person2.Balance -= car.Price;
                        Console.WriteLine("Car purchased successfully.");
                        Console.WriteLine($"{back}");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                    case "x":
                    return;

                        
            }
        }

    }
 }
