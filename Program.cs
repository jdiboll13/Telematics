using System;
using System.Collections;
using System.IO;

namespace Telematics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter Vehicle Identification Number:");
            var vinInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Odometer reading:");
            var odometerInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the miles per gallons for the vehicle:");
            var consumptionInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Odometer reading from the last oil change:");
            var odometerLastOilChangeInput = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Engine size of the vehicle:");
            var engineSizeInput = int.Parse(Console.ReadLine());

            var newVehicle = new VehicleInfo(vinInput, odometerInput, consumptionInput, odometerLastOilChangeInput, engineSizeInput); 
            new TelematicsService().Report(newVehicle);
            new TelematicsService().HtmlReport(newVehicle);
        }
    }
}
