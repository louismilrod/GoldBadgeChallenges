using _06_KomodoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;


namespace _06_KomodoGreenPlan_UI_
{
    public class ProgramUI
    {
        private readonly Car_Repository _repository = new Car_Repository();
        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Green Initiative\n" +
                    "1. Add A Brand New Car \n" +
                    "2. View All Existing Cars \n" +
                    "3. View Cars By Fuel Type \n" +
                    "4. Delete Vehicle");

                string userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ViewAllCars();
                        break;
                    case "3":
                        ViewCarsByFuelType();
                        break;
                    case "4":
                        RemoveCar();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
                Clear();
            }
        }

        private void AddCar()
        {
            Clear();

            var car = new Car();

            WriteLine("Please select a car type to crate \n" +
                "1. Gas \n" +
                "2. Electric \n" +
                "3. Hybrid \n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    car = new Gas();
                    car.FuelType = TypeOfFuel.Gas;
                    break;
                case "2":
                    car = new Electric();
                    car.FuelType = TypeOfFuel.Electric;
                    break;
                case "3":
                    car = new Hybrid();
                    car.FuelType = TypeOfFuel.Hybrid;
                    break;
                default:
                    WriteLine("Invalid Selection");
                    break;
            }
            WriteLine("What is the make?");
            car.CarBrand = ReadLine();
            _repository.AddCarToDataBase(car);
            ReadKey();
        }

        private void ViewAllCars()
        {
            Clear();
            List<Car> cars = _repository.GetAllCars();
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
            ReadKey();

        }


        private void ViewCarsByFuelType()
        {
            Clear();

            Console.WriteLine("View cars by Fuel Type \n" +
                "1. Gas \n" +
                "2. Electric \n" +
                "3. Hybrid \n");

            var userInput = ReadLine();
            //userInput = Convert.ToInt32(userInput);

            switch (userInput)
            {
                case "1":
                    var gasCars = _repository.GetCarsByType(TypeOfFuel.Gas);
                    foreach (Car item in gasCars)
                    {
                        Clear();
                        Console.WriteLine("Showing all Gas Cars: \n");
                        Console.WriteLine(item.ToString());
                    }
                    ReadKey();
                    break;
                case "2":
                    var electricCars = _repository.GetCarsByType(TypeOfFuel.Electric);
                    foreach (Car item in electricCars)
                    {
                        Clear();
                        Console.WriteLine("Showing all Electric Cars: \n");
                        Console.WriteLine(item.ToString());
                    }
                    ReadKey();
                    break;
                case "3":
                    var hybridCars = _repository.GetCarsByType(TypeOfFuel.Hybrid);
                    foreach (Car item in hybridCars)
                    {
                        Clear();
                        Console.WriteLine("Showing all Hybrid Cars: \n");
                        Console.WriteLine(item.ToString());
                    }
                    ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid selection");
                    ReadKey();
                    break;
            }
        }

        private void RemoveCar()
        {
            ViewAllCarsButWait();
            //Car item1 = ViewAllCars();
            WriteLine("Which vehicle do you wish to remove?");
            // WriteLine(item1);
            Car item = _repository.GetSingleCar(int.Parse(ReadLine()));
            if (item != null)
            {
                var success = _repository.DeleteExistingContent(item);
                if (success)
                {
                    Console.WriteLine("SUCCESS");                    
                }
                else
                {
                    Console.WriteLine("FAIL");                   
                }
            }

            if (item == null)
            {
                Console.WriteLine($"This is not the car you are looking for");
            }
            ReadKey();
        }
        private void ViewAllCarsButWait()
        {
            Clear();
            List<Car> cars = _repository.GetAllCars();
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
            Thread.Sleep(750);
        }

        private void Seed()
        {
            Car Thunderbird = new Car();
            Thunderbird.FuelType = TypeOfFuel.Gas;
            Thunderbird.CarBrand = "Ford";
            _repository.AddCarToDataBase(Thunderbird);

            Car Tesla = new Car();
            Tesla.FuelType = TypeOfFuel.Electric;
            Tesla.CarBrand = "Tesla";
            _repository.AddCarToDataBase(Tesla);
        }


        private void WaitForKey()
        {
            ReadKey();
        }
    }
}
