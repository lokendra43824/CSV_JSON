using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using JSONFIleDemo;

namespace JSONFileDemo
{
   
        public class ReadCSV_And_Write_JSON
        {
        public static void JsonWriter()
        {
            string importFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\CsvFile\CsvFile\address.csv";
            string exportFilePath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\CsvFile\CsvFile\addressJ.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Reading Data ......\n");

                foreach (AddressData address in records)
                {
                    Console.WriteLine(" " + address.FirstName);
                    Console.WriteLine(" " + address.LastName);
                    Console.WriteLine(" " + address.Address);
                    Console.WriteLine(" " + address.City);
                    Console.WriteLine(" " + address.State);
                    Console.WriteLine(" " + address.Code + "\n");

                }
                Console.WriteLine("Readed Data successFully");

                Console.WriteLine("Writing Data:");

                //JsonSerializer serializer = new JsonSerializer();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
                Console.WriteLine("Writed Data successfully:");
            }
        }
    }

}

