using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Telematics
{
    public class TelematicsService
    {
        JsonSerializer serializer = new JsonSerializer();
        public void Report(VehicleInfo vehicleInfo)
        {
            using (var writer = new StreamWriter(File.Open($"{vehicleInfo.VIN}.json", FileMode.OpenOrCreate)))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(writer, vehicleInfo);
            }
        }

        public void HtmlReport(VehicleInfo vehicleInfo)
        {
            string[] files = System.IO.Directory.GetFiles(".", "*.json");
            List<object> vehicleList = new List<object>();
            var totalOdometer = 0d;
            var totalConsumption = 0d;
            var totalLastOil = 0d;
            var totalEngine = 0d;
            var itemTemplate = @"<tr>
            <td align = 'center'>{0}</td><td align='center'>{1}</td><td align='center'>{2}</td><td align='center'>{3}</td align='center'><td align='center'>{4}</td>
            </tr>";
            var tableHTML = string.Empty;
            foreach (var item in files)
            {
                using (StreamReader file = File.OpenText(item))
                {
                    var vehicleInfoObj = JsonConvert.DeserializeObject<VehicleInfo>(file.ReadToEnd());
                    vehicleList.Add(vehicleInfoObj);
                    totalOdometer += vehicleInfoObj.Odometer;
                    totalConsumption += vehicleInfoObj.Consumption;
                    totalLastOil += vehicleInfoObj.OdometerLastOilChange;
                    totalEngine += vehicleInfoObj.EngineSize;
                    tableHTML += string.Format($"{itemTemplate}",vehicleInfoObj.VIN,vehicleInfoObj.Odometer,vehicleInfoObj.Consumption,vehicleInfoObj.OdometerLastOilChange,vehicleInfoObj.EngineSize);
                }
            }

            var odometerAvg = totalOdometer / vehicleList.Count;
            var consumpAvg = totalConsumption / vehicleList.Count;
            var lastOilAvg = totalLastOil / vehicleList.Count;
            var engAvg = totalEngine / vehicleList.Count;
            string html = $@"<html>
            <title>Vehicle Telematics Dashboard</title>
            <body>
            <h1 align='center'>Averages for All Vehicles</h1>
            <table align='center'>
            <tr>
            <th>Odometer (miles) |</th><th>Consumption (gallons) |</th><th>Last Oil Change |</th><th>Engine Size (liters)</th>
            </tr>
            <tr>
            <td align='center'>{odometerAvg:0.0}</td><td align='center'>{consumpAvg:0.0}</td><td align='center'>{lastOilAvg:0.0}</td align='center'><td align='center'>{engAvg:0.0}</td>
            </tr>
            </table>
            <h1 align='center'>History</h1>
            <table align = 'center' border = '1'>
            <tr>
            <th> VIN </th><th> Odometer(miles) </th><th> Consumption(gallons) </th><th> Last Oil Change </th><th> Engine Size(liters) </th>
            </tr>
            {tableHTML}
            </table>
            </body>
            </html>";
            using (var writer = new StreamWriter(File.Open($"dashboard.html", FileMode.OpenOrCreate)))
            {
                writer.WriteLine(html);
            }
        }
    }
}

