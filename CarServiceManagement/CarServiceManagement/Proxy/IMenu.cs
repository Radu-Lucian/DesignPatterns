using CarServiceManagement.State;

namespace CarServiceManagement.Proxy
{
    public interface IMenu
    {
        void LogOut();
        void RentACar();
        void ServiceCar(Car car);
        void CheckCar(Car car);
        void Exit();
        void PrintCarsInService();

    }
}
