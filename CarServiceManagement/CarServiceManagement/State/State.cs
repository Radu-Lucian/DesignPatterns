namespace CarServiceManagement.State
{
    public abstract class State
    {
        public Car Car { get; set; }

        public State(Car car)
        {
            Car = car;
        }

        public abstract void CheckCar();

        public abstract void RepairCar();

        public abstract void CheckOutCar();
    }
}
