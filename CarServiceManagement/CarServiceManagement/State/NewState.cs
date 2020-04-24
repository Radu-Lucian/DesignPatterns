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
            CheckCarCommand.Execute("Car is in new state");
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Car is not ready");
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Car was sent to the service");
            Car.SetCarState(Car.NotStartedState);
            Logger.Instance.LogOk("Car changed state");
        }
    }
}
