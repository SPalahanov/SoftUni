using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SpeedRacing
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        //public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelDistance)
        //{
        //    this.Model = model;
        //    this.FuelAmount = fuelAmount;
        //    this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        //    this.TravelledDistance = travelDistance;
        //}

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void CalculateDriving(double distance) 
        {
            if (distance * FuelConsumptionPerKilometer > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                TravelledDistance += distance;
            }
        }
    }
}
