using System;

namespace Telematics
{
    public class VehicleInfo
    {
        public int VIN { get; set; }
        public double Odometer { get; set; }
        public double Consumption { get; set; }
        public double OdometerLastOilChange { get; set; }
        public double EngineSize { get; set; }
        public VehicleInfo(int vin, double odometer, double consumption, double odometerLastOilChange, double engineSize)
        {
            VIN = vin;
            Odometer = odometer;
            Consumption = consumption;
            OdometerLastOilChange = odometerLastOilChange;
            EngineSize = engineSize;
        }
        public override string ToString()
        {
            return $"The VIN is {VIN}, it has {Odometer} miles, it gets {Consumption} miles to the gallon. It's last oil change was at {OdometerLastOilChange} miles and it has an engine size of {EngineSize}.";
        }
        

    }
} 