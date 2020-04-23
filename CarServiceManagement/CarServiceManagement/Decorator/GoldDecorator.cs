using CarServiceManagement.Util;

namespace CarServiceManagement.Decorator
{
    public class GoldDecorator : PackageDecorator
    {

        public GoldDecorator(IPackage package) : base(package)
        {
            package.Type = EPackageType.EGold;
            Update();
        }
        public override void Update()
        {
            DecoratedPackage.Price += 500;
            ServicesIncluded = "Car with 1.6 diesel engine.";
        }
        public override int PackTime()
        {
            return 4;
        }
    }
}
