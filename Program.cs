using System;
using System.Text;
using Weather = CSLab.CoreTypes.Enums.Weather;
using TypeChecker = CSLab.TypesAndSizes;
using static CSLab.CoreTypes.Interfaces.Vehicle;
using System.Runtime.InteropServices;

namespace CSLab
{
    class CSLab
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = Weather.GetDaysArray();
            Console.WriteLine(Weather.DisplayAllDays(daysOfWeek));            

            Console.WriteLine(Weather.DisplayAllTemperatures());

            TypeChecker.DisplayTypeInternalName<long>(); // Provided type "System.Int64" internal class name: Int64
            TypeChecker.DisplayTypeInternalName<ushort>(); // Provided type "System.UInt16" internal class name: UInt16
            TypeChecker.DisplaySizeOfType<decimal>(); // Provided type has size of 16 Bytes

            List<IVehicle> vehicles = new List<IVehicle>();

            Car car1 = new Car("BMW", "Diesel", 205);
            Car car2 = new Car("Renault", "Petrol", 160);

            Truck truck1 = new Truck("Scania", "Petrol", 150);
            Truck truck2 = new Truck("Mercedes", "Diesel", 170, 12);

            vehicles.Add(car1); vehicles.Add(car2);
            vehicles.Add(truck1); vehicles.Add(truck2);

            foreach(var vehicle in vehicles)
            {                
                vehicle.Start(); // Car (BMW) started, Car (Renault) started, Truck (Scania) started, Truck (Mercedes) started
                if(vehicle is Car) vehicle.Stop(); // Car (BMW) stopped, Car (Renault) stopped                                   
                if (vehicle.Name == "Scania") vehicle.Refuel(114); // Scania refueled with 114L of Petrol
                if (vehicle.TiresCount > 8) vehicle.GetVehicleInfo(); // Mercedes: 12 tires, Diesel fuel, max speed: 170 km/h
            }

            
        }
    }
}