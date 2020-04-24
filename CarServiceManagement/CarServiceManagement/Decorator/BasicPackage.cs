using CarServiceManagement.Util;

namespace CarServiceManagement.Decorator
{
    public class BasicPackage : IPackage
    {
        public EPackageType Type { get; set; }
        public int Price { get; set; }
        public string ServicesIncluded { get; set; }
        public int PackTime { get; set; }

        public BasicPackage()
        {
            Type = EPackageType.EBasic;
            Update();
        }

        public void Update()
        {
            Price = 1500;
            ServicesIncluded = "Car with 1.4 gas engine.";
            PackTime = 2;
        }

        public override string ToString()
        {
            return Type.ToString() + " " + ServicesIncluded + ": " + Price + " RON; "+PackTime+" days included";
        }

        public virtual int GetPackTime()
        {
            return 2;
        }
    }
}
