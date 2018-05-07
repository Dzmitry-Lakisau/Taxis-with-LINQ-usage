using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxis.Lib.Classes;
using Taxis.Lib.Enums;

namespace Taxis
{
    class Program
    {
        static void Main(string[] args)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path.Substring(0, path.IndexOf("\\bin")));

            using (TaxisDatabase database = new TaxisDatabase())
            {
                try
                {
                    //Sedan sedan = new Sedan("1234 AB-4", "Audi A4", 8000, 8.1, 200.3, 4, ComfortType.Standard);
                    //database.Sedans.Add(sedan);
                    //sedan = new Sedan("7823 AT-4", "Peugeot 407", 5400, 6.5, 160, 4, ComfortType.Standard);
                    //database.Sedans.Add(sedan);
                    //sedan = new Sedan("1111 XX-4", "Audi R8", 77300, 13, 320, 2, ComfortType.Premium);
                    //database.Sedans.Add(sedan);
                    //database.SaveChanges();

                    //Minivan minivan = new Minivan("5321 CT-4", "Chrysler Pacifica", 26000, 9.6, 200, 6, true);
                    //database.Minivans.Add(minivan);
                    //minivan = new Minivan("7826 PO-4", "Kia Sedona", 27400, 6.5, 140, 6, false);
                    //database.Minivans.Add(minivan);
                    //minivan = new Minivan("9264 WS-4", "Chrysler Pacifica Hybrid", 45000, 3.6, 147, 6, true);
                    //database.Minivans.Add(minivan);
                    //database.SaveChanges();

                    int sum = ((from car in database.Sedans select car.Cost).Concat(
                    from car in database.Minivans select car.Cost)).Sum();
                    Console.WriteLine("Total cost of all taxis: {0}", sum);

                    Console.WriteLine("--------------------------------");

                    var cars = database.Cars.OrderBy(car => car.FuelEconomy);
                    Console.WriteLine("Sorted by fuel economy:");
                    foreach (var car in cars)
                    {
                        car.PrintToConsole();
                    }

                    Console.WriteLine("--------------------------------");

                    Console.WriteLine("Enter start of range of speed");
                    double start = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter end of range speed");
                    double end = Convert.ToDouble(Console.ReadLine());

                    var sedans = (from car in database.Sedans select (Car)car).
                                Where(s => s.MaxSpeed >= start && s.MaxSpeed <= end);
                    var minivans = (from car in database.Minivans select (Car)car).
                                Where(s => s.MaxSpeed >= start && s.MaxSpeed < end);
                    var result = sedans.Union(minivans);

                    Console.WriteLine("Cars with MaxSpeed between {0} and {1}:", start, end);
                    foreach (var car in result)
                    {
                        car.PrintToConsole();
                    }
                }
                catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    string err = e.InnerException.Message;
                }
            }
                Console.Read();
            }
        }
    }
}
