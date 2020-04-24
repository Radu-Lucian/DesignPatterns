using CarServiceManagement.Util;

namespace CarServiceManagement.State
{
    public class Car
    {
        public CarDetails CarDetails;
        public State CarState;
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
            CarState = NewState;
        }

        public void UpdateState(EStateOption option)
        {
            switch (option)
            {
                case EStateOption.CheckCar:
                    CarState.CheckCar();
                    break;
                case EStateOption.RepairCar:
                    CarState.RepairCar();
                    break;
                case EStateOption.CheckOutCar:
                    CarState.CheckOutCar();
                    break;
                default:
                    break;
            }
        }
        public void SetCarState(State newState)
        {
            CarState = newState;
        }

        public override string ToString()
        {
            return $"Car: {CarDetails.CarBrand}, Color: {CarDetails.Color}, VIN: {CarDetails.VIN}, License Plate: {CarDetails.LicensePlate}, State: {CarState}";
        }

    }
}
