using CarServiceManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
