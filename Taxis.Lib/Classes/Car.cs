using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Taxis.Lib.Classes
{
    public abstract class Car
    {

        public Car(string registrationNumber, string model, int cost, double fuelEconomy, double maxSpeed, int countOfPlaces)
        {
            RegistrationNumber = registrationNumber;
            Model = model;
            Cost = cost;
            FuelEconomy = fuelEconomy;
            MaxSpeed = maxSpeed;
            CountOfPlaces = countOfPlaces;
        }

        protected Car() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String RegistrationNumber { get; private set; }

        public String Model { get; private set; }
        public int Cost { get; private set; }

        public double FuelEconomy { get; private set; }

        public double MaxSpeed { get; private set; }

        public int CountOfPlaces { get; private set; }
    }
}
