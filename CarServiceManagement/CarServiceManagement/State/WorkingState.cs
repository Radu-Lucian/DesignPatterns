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
            CheckCarCommand.Execute("Working on car");
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Car sent to finish checks");
            Car.SetCarState(Car.FixedState);
            Logger.Instance.LogOk("Car changed state");
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Curently working on car");
        }
    }
}
