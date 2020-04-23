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
            DecoratedPackage.Price += 700;
            ServicesIncluded = "Car with 2.0 diesel or gas engine + 1.000 EUR car crash insurance";
        }

        public override int PackTime()
        {
            return 7;
        }
    }
}
