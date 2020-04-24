using CarServiceManagement.State;
using CarServiceManagement.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Repository
{
    public class CarRepository
    {
        private static CarRepository _instance = null;
        private static readonly object _padlock = new object();

        private readonly List<Car> Cars = new List<Car>
        {
            new Car(new CarDetails(ECarType.EDiesel, "Ford", "grey", "2FMHK6DT7FBA13402", "BV 29 STO")),
            new Car(new CarDetails(ECarType.EDiesel, "VW", "grey", "2FMHK6DT7FBA101010", "BV 98 RIM")),
            new Car(new CarDetails(ECarType.EDiesel, "VW", "black", "2FMHK6DT7FBA251530", "BV 98 SGA")),
            new Car(new CarDetails(ECarType.EDiesel, "Mercedes", "grey", "2FMHK6DT7FBA653587", "BV 10 ABC"))
        };

        public CarRepository()
        {

        }

        public static CarRepository Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new CarRepository();
                    }
                    return _instance;
                }
            }
        }

        public Car GetCar(string VIN)
        {
            foreach (var car in Cars)
            {
                if (car.CarDetails.VIN == VIN)
                {
                    return car;
                }
            }

            return null;
        }
    }
}
