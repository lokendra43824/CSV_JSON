using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
namespace JSONFIleDemo
{
    class CsvHandler
    {
        public static void ImplementCsvDataHandling()
        {
            string importPath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\CsvFile\CsvFile\address.csv";
            string exportPath = @"C:\Users\NAGENDRA AND JANAKI\source\repos\CsvFile\CsvFile\export.csv";

            using (var reader = new StreamReader(importPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("read data successfully");

                foreach (AddressData address in records)
                {
                   
                    Console.WriteLine("\t" + address.FirstName);
                    Console.WriteLine("\t" + address.LastName);
                    Console.WriteLine("\t" + address.Address);
                    Console.WriteLine("\t" + address.City);
                    Console.WriteLine("\t" + address.State);
                    Console.WriteLine("\t" + address.Code);
                    Console.WriteLine("\n");
                }


                using (var writer = new StreamWriter(exportPath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }

    }
}