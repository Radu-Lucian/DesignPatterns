using CarServiceManagement.Util;

namespace CarServiceManagement.State
{
    public class Car
    {
        public CarDetails CarDetails;
        public State carState;

        public State FixedState { get; set; }
        public State WorkingOnState { get; set; }
        public State NotStartedState { get; set; }
        public State NewState { get; set; }

        public Car(CarDetails carDetails)
        {
            CarDetails = carDetails;
            FixedState = new FixedState(this);
            WorkingOnState = new WorkingState(this);
            NotStartedState = new NotStartedState(this);
            NewState = new NewState(this);
            carState = NewState;
        }

        public void UpdateState(EStateOption option)
        {
            switch (option)
            {
                case EStateOption.CheckCar:
                    carState.CheckCar();
                    break;
                case EStateOption.RepairCar:
                    carState.RepairCar();
                    break;
                case EStateOption.CheckOutCar:
                    carState.CheckOutCar();
                    break;
                default:
                    break;
            }
        }
        public void SetCarState(State newState)
        {
            carState = newState;
        }

    }
}
