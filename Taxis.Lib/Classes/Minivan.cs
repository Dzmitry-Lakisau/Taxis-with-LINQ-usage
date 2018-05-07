using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxis.Lib.Classes
{
    public class Minivan: Car
    {
        public Minivan(string registrationNumber, string model, int cost, double fuelEconomy, double maxSpeed, int countOfPlaces, bool isLastRowIsCollapsable):base(registrationNumber, model, cost, fuelEconomy, maxSpeed, countOfPlaces)
        {
            IsLastRowIsCollapsable = isLastRowIsCollapsable;
        }

        private Minivan() { }

        public bool IsLastRowIsCollapsable { get; private set; }

        public override void PrintToConsole()
        {
            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | Last row of places {6} collapsable", RegistrationNumber, Model, Cost, FuelEconomy, MaxSpeed, CountOfPlaces,
                    IsLastRowIsCollapsable ? "is"  : "is not");
        }
    }
}
