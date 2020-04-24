using CarServiceManagement.Command;

namespace CarServiceManagement.State
{
    public abstract class State
    {
        public Car Car { get; set; }

        public ICommand CheckCarCommand { get; set; }
        public ICommand RepairCarCommand { get; set; }
        public ICommand CheckOutCarCommand { get; set; }

        public State(Car car)
        {
            Car = car;
            CheckCarCommand = new CheckCarCommand();
            RepairCarCommand = new RepairCarCommand();
            CheckOutCarCommand = new CheckOutCarCommand();
        }

        public abstract void CheckCar();

        public abstract void RepairCar();

        public abstract void CheckOutCar();
    }
}
