using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceManagement.Decorator
{
    public class BasicPackage : IPackage
    { 
        public EPackageType Type { get ; set ; }
        public int Price { get ; set ; }
        public string ServicesIncluded { get ; set ; }

        public BasicPackage()
        {
            Type = EPackageType.EBasic;
            Update();
        }

        public void Update()
        {
            Price = 1000;
            ServicesIncluded = "Car with 1.4 gas engine.";
        }

        public override string ToString()
        {
            return this.GetType().Name + " " + ServicesIncluded + ": " + Price + " RON per day";
        }
    }
}
