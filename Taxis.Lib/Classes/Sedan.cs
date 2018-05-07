using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxis.Lib.Enums;

namespace Taxis.Lib.Classes
{
    public class Sedan: Car, Interfaces.Printable
    {
        public Sedan(string registrationNumber, string model, int cost, double fuelEconomy, double maxSpeed, int countOfPlaces, ComfortType comfortType):base(registrationNumber, model, cost, fuelEconomy, maxSpeed, countOfPlaces)
        {
            ComfortType = comfortType;
        }

        private Sedan() { }

        public ComfortType ComfortType { get; private set; }

        public override void PrintToConsole()
        {
            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", RegistrationNumber, Model, Cost, FuelEconomy, MaxSpeed, CountOfPlaces, ComfortType);
        }
    }
}
