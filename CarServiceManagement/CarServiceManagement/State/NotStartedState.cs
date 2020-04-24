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
            CheckCarCommand.Execute("Car is in service, not curently worked on");
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Car is not ready");
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Started working on car");
            Car.SetCarState(Car.WorkingOnState);
            Logger.Instance.LogOk("Car changed state");
        }
    }
}
