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
            Console.WriteLine("Car is fixed");
        }

        public override void CheckOutCar()
        {
            Console.WriteLine("Your car is ready for pickup");
        }

        public override void RepairCar()
        {
            Console.WriteLine("Your car is already fixed");
        }
    }
}
