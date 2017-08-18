using System;
using System.IO;
using System.Collections;
using Newtonsoft.Json;

namespace Telematics
{
    public class TelematicsService
    {
        //Learn more about serialize and it's purpose and what it's doing
        JsonSerializer serializer = new JsonSerializer();
        public void Report(VehicleInfo vehicleInfo)
        {
            using (var writer = new StreamWriter(File.Open($"{vehicleInfo.VIN}.json", FileMode.OpenOrCreate)))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(writer, vehicleInfo);
            }
            //Loop through all the filenames...
            //Then pull the info from each fill and then
            //Deserialize the info
            //Then take that json object and push it to html?
            using (var reader = new StreamReader(File.Open("all the json files that have been created", FileMode.OpenOrCreate)))
            {
                // while (reader.Peek() >= 0)
                // {
                //     var  = reader.ReadToEnd();

                //     var data = contactFromFile.Split(',');
                //     phoneFromFile.Add(new Contact(data));
                // }                
            }
        }
    }
    
}

