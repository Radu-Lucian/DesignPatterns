using CarServiceManagement.Logging;
using System;

namespace CarServiceManagement.State
{
    public class WorkingState : State
    {
        public WorkingState(Car car) : base(car)
        {
        }

        public override void CheckCar()
        {
            Console.WriteLine("Working on car");
        }

        public override void CheckOutCar()
        {
            Console.WriteLine("Car sent to finish checks");
            Car.SetCarState(Car.FixedState);
            Logger.Instance.LogOk("Car changed state");
        }

        public override void RepairCar()
        {
            Console.WriteLine("Curently working on car");
        }

        public override string ToString()
        {
            return "Working";
        }
    }
}
