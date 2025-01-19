using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CSLab.CoreTypes.Interfaces
{
    internal class Vehicle
    {
        public interface IVehicle
        {
            public string Name { get; set; }
            public int TiresCount { get; set; }
            public string FuelType { get; set; }
            public double MaxSpeed { get; set; }
            public double CurrentSpeed { get; set; }

            public void Start();
            public void Stop();
            public void Refuel(double liters);
            public void Accelerate(double speed);
            public void Decelerate(double speed);
            public void GetVehicleInfo();
        }

        public class Car : IVehicle
        {
            public string Name { get; set; }
            public int TiresCount { get; set; }
            public string FuelType { get; set; }
            public double MaxSpeed { get; set; }
            public double CurrentSpeed { get; set; }

            public Car(string name, string fuelType, double maxSpeed)
            {
                Name = name;
                FuelType = fuelType;
                MaxSpeed = maxSpeed;
                TiresCount = 4;
                CurrentSpeed = 0;
            }
            public void Start() => Console.WriteLine($"Car ({Name}) started");
            public void Stop() => Console.WriteLine($"Car ({Name}) stopped");
            public void Refuel(double liters) => Console.WriteLine($"{Name} refueled with {liters}L of {FuelType}");
            public void Accelerate(double speed) => CurrentSpeed = Math.Min(CurrentSpeed + speed, MaxSpeed);
            public void Decelerate(double speed) => CurrentSpeed = Math.Max(CurrentSpeed - speed, 0);
            public void GetVehicleInfo() => Console.WriteLine($"{Name}: {TiresCount} tires, {FuelType} fuel, max speed: {MaxSpeed} km/h");
        }

        public class Truck : IVehicle
        {
            public string Name { get; set; }
            public int TiresCount { get; set; }
            public string FuelType { get; set; }
            public double MaxSpeed { get; set; }
            public double CurrentSpeed { get; set; }

            public Truck(string name, string fuelType, double maxSpeed, int tiresCount = 8)
            {
                Name = name;
                FuelType = fuelType;
                MaxSpeed = maxSpeed;
                TiresCount = tiresCount;
                CurrentSpeed = 0;
            }
            public void Start() => Console.WriteLine($"Truck ({Name}) started");
            public void Stop() => Console.WriteLine($"Truck ({Name}) stopped");
            public void Refuel(double liters) => Console.WriteLine($"{Name} refueled with {liters}L of {FuelType}");
            public void Accelerate(double speed) => CurrentSpeed = Math.Min(CurrentSpeed + speed, MaxSpeed);
            public void Decelerate(double speed) => CurrentSpeed = Math.Max(CurrentSpeed - speed, 0);
            public void GetVehicleInfo() => Console.WriteLine($"{Name}: {TiresCount} tires, {FuelType} fuel, max speed: {MaxSpeed} km/h");
        }

    }
}
