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
            CheckCarCommand.Execute("Car is: in service but not revised");
            Car.CarDetails.CheckCarState();
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Car is not ready");
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Your car is already in the service.");
            //Car.SetCarState(Car.WorkingOnState);
            //Logger.Instance.LogOk("Car changed state");
        }

        public override string ToString()
        {
            return "Car is: not revised yet";
        }
    }
}
