using System;
using System.Text;
using Weather = CSLab.CoreTypes.Enums.Weather;
using TypeChecker = CSLab.TypesAndSizes;
using static CSLab.CoreTypes.Interfaces.Vehicle;
using System.Runtime.InteropServices;
using CSLab.CoreTypes.Delegates;

namespace CSLab
{
    class CSLab
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = Weather.GetDaysArray();

            Console.WriteLine(Weather.DisplayAllDays(daysOfWeek));                        

            TypeChecker.DisplayTypeInternalName<long>();
            TypeChecker.DisplayTypeInternalName<ushort>();
            TypeChecker.DisplaySizeOfType<decimal>();

            List<IVehicle> vehicles = new List<IVehicle>();

            Car car1 = new Car("BMW", "Diesel", 205);
            Car car2 = new Car("Renault", "Petrol", 160);

            Truck truck1 = new Truck("Scania", "Petrol", 150);
            Truck truck2 = new Truck("Mercedes", "Diesel", 170, 12);

            vehicles.Add(car1); vehicles.Add(car2);
            vehicles.Add(truck1); vehicles.Add(truck2);

            foreach(var vehicle in vehicles)
            {                
                vehicle.Start();
                if(vehicle is Car) vehicle.Stop();
                if (vehicle.Name == "Scania") vehicle.Refuel(114);
                if (vehicle.TiresCount > 8) vehicle.GetVehicleInfo();
            }

            var video = new Video() { Title = "Dependency Injection in C#" };
            var videoEncoder = new VideoEncoder(); // Publisher

            var mailService = new MailService();
            var messageService = new MessageService();
            
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; 
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            
            videoEncoder.Encode(video);
            
        }
    }
}