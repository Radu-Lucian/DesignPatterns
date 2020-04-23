using CarServiceManagement.Util;
using System;

namespace CarServiceManagement.State
{
    public class CarDetails
    {
        public ECarType CarType { get; set; }
        public string CarBrand { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public string LicensePlate { get; set; }

        public CarFaultsManager CarFaultsManager;


        public CarDetails(ECarType type, string brand, string color, string vin, string plate)
        {
            this.CarBrand = brand;
            this.CarType = type;
            this.Color = color;
            this.VIN = vin;
            this.LicensePlate = plate;
        }

        public override string ToString()
        {
            return "CarBrand: " + CarBrand +
                " CarType: " + CarType.ToString() +
                " Color: " + Color +
                " VIN: " + VIN +
                " LicensePlate: " + LicensePlate + "\n";
        }

        public void CheckCarState()
        {
            if (CarFaultsManager != null)
            {
                CarFaultsManager.PrintFaults();
                CarFaultsManager.GetCurrentProgress();
            }
            else
            {
                Console.WriteLine("Your car is not in our service. If you do have a faulty car, though, do not hesitate to contact us.");
            }
        }

        public void CarGoesToService()
        {
            CarFaultsManager = new CarFaultsManager();
            Console.WriteLine("Your car has entered our service!");
        }
    }
}