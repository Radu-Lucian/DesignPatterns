using System;

namespace CarServiceManagement.State
{
    public class FixedState : State
    {
        public FixedState(Car car) : base(car)
        {
        }

        public override void CheckCar()
        {
            CheckCarCommand.Execute("Car is fixed");
        }

        public override void CheckOutCar()
        {
            CheckOutCarCommand.Execute("Your car is ready for pickup");
        }

        public override void RepairCar()
        {
            RepairCarCommand.Execute("Your car is already fixed");
        }

        public override string ToString()
        {
            return "Fixed";
        }
    }
}
