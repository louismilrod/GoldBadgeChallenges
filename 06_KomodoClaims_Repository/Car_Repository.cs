using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoClaims_Repository
{
    public class Car_Repository
    {
        private readonly List<Car> _carDatabase = new List<Car>();

        private int _count;

        public bool AddCarToDataBase(Car car)
        {
            if (car == null)
                return false;
            else
            {
                _count++;
                car.CarID = _count;
                _carDatabase.Add(car);
                return true;
            }
        }

        public List<Car> GetAllCars()
        {
            return _carDatabase;
        }

        public Car GetSingleCar(int index)
        {
            foreach (var item in _carDatabase)
            {
                if (item.CarID == index)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Car> GetCarsByType(TypeOfFuel typeOfFuel) ///GetCarsByType (Electric)
        {
            List<Car> cars = new List<Car>();
            foreach (var item in _carDatabase)
            {
                if (item.FuelType == typeOfFuel)
                {
                    cars.Add(item);
                }
            }return cars;
        }

        public bool DeleteExistingContent(Car car)
        {
            bool deleteResult = _carDatabase.Remove(car);
            return deleteResult;
        }

    }
}
