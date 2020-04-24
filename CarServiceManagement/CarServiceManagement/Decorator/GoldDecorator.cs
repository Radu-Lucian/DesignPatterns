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
            DecoratedPackage.Price += 1000;
            DecoratedPackage.ServicesIncluded = "Car with 1.6 diesel engine.";
            DecoratedPackage.PackTime += 2;
        }
        public override int GetPackTime()
        {
            return 4;
        }
    }
}
