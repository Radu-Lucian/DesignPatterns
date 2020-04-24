using CarServiceManagement.Logging;
using System;

namespace CarServiceManagement.State
{
    public class NotStartedState : State
    {
        public NotStartedState(Car car) : base(car)
        {
        }

        public override void CheckCar()
        {
            Console.WriteLine("Car is in service, not curently worked on");
        }

        public override void CheckOutCar()
        {
            Console.WriteLine("Car is not ready");
        }

        public override void RepairCar()
        {
            Console.WriteLine("Started working on car");
            Car.SetCarState(Car.WorkingOnState);
            Logger.Instance.LogOk("Car changed state");
        }
    }
}
