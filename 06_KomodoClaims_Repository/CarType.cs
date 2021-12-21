using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoClaims_Repository
{
    public enum TypeOfFuel
    {
        Gas = 1,
        Electric,
        Hybrid
    }
    public class Car
    {
        public Car()
        {

        }

        public Car(TypeOfFuel fuelType, string carBrand)
        {
            FuelType = fuelType;
            CarBrand = carBrand;
        }
        public int CarID { get; set; }
        public TypeOfFuel FuelType { get; set; } 
        public string CarBrand { get; set; }

        public override string ToString()
        {
            return $"CarID: {CarID}\n" +
                $"Car Brand: {CarBrand}\n" +
                $"Type Of Fuel: {FuelType}\n" +
                $" ";       
        }

    }

    public class Electric : Car
    {
        public Electric()
        {
           TypeOfFuel = TypeOfFuel.Electric;
        }

        TypeOfFuel TypeOfFuel { get; set; }
        
    }

    public class Hybrid : Car
    {
        public Hybrid()
        {
            TypeOfFuel = TypeOfFuel.Hybrid;
        }
        TypeOfFuel TypeOfFuel { get; set; } 
        
    }

    public class Gas : Car
    {
        public Gas()
        {
            TypeOfFuel = TypeOfFuel.Gas;
        }
        TypeOfFuel TypeOfFuel { get; set; }      
    }

}
