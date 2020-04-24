using CarServiceManagement.Util;

namespace CarServiceManagement.Decorator
{
    public class PlatinumDecorator : PackageDecorator
    {
        public PlatinumDecorator(IPackage package) : base(package)
        {
            package.Type = EPackageType.EPlatinum;
            Update();
        }
        public override void Update()
        {
            DecoratedPackage.Price += 2000;
            DecoratedPackage.ServicesIncluded = "Car with 2.0 diesel or gas engine + 1.000 EUR car crash insurance";
            DecoratedPackage.PackTime += 3;
        }

        public override int GetPackTime()
        {
            return 7;
        }
    }
}
