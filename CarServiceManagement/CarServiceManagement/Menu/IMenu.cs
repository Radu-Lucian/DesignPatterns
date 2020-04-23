using CarServiceManagement.State;

namespace CarServiceManagement.Menu
{
    public interface IMenu
    {
        void LogOut();
        void RentACar();
        void ServiceCar(Car car);
        void CheckCar(Car car);
        void Exit();

    }
}
