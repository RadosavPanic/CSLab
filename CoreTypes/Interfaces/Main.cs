using System;
using static CSLab.CoreTypes.Interfaces.Vehicle;

namespace CSLab.CoreTypes.Interfaces
{
    public class Main
    {
        public static void Run()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            Car car1 = new Car("BMW", "Diesel", 205);
            Car car2 = new Car("Renault", "Petrol", 160);

            Truck truck1 = new Truck("Scania", "Petrol", 150);
            Truck truck2 = new Truck("Mercedes", "Diesel", 170, 12);

            vehicles.Add(car1); vehicles.Add(car2);
            vehicles.Add(truck1); vehicles.Add(truck2);

            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
                if (vehicle is Car) vehicle.Stop();
                if (vehicle.Name == "Scania") vehicle.Refuel(114);
                if (vehicle.TiresCount > 8) vehicle.GetVehicleInfo();
            }
        }
    }
}
