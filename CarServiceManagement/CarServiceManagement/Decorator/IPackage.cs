using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Decorator
{
    public interface IPackage
    {
        EPackageType Type { get; set; }

        int Price { get; set; }

        string ServicesIncluded { get; set; }

        void Update();

        string ToString();
    }
}
