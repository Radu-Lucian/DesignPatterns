using CarServiceManagement.Logging;
using System;

namespace CarServiceManagement.State
{
    public class NewState : State
    {
        public NewState(Car car) : base(car)
        {
        }

        public override void CheckCar()
        {
            Console.WriteLine("Car is in new state");
        }

        public override void CheckOutCar()
        {
            Console.WriteLine("Car is not ready");
        }

        public override void RepairCar()
        {
            Console.WriteLine("Car was sent to the service");
            Car.SetCarState(Car.NotStartedState);
            Logger.Instance.LogOk("Car changed state");
        }
    }
}
