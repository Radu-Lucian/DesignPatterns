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
            CheckCarCommand.Execute("Car is: worked on");
            Car.CarDetails.CheckCarState();
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Car sent to final checks.");
            Car.SetCarState(Car.FixedState);
            Logger.Instance.LogOk("Car changed state to"+Car.CarState);
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Your car is already in the service.");
        }

        public override string ToString()
        {
            return "Car is: worked on";
        }
    }
}
