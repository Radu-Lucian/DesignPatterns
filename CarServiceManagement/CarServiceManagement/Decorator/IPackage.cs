using CarServiceManagement.Util;

namespace CarServiceManagement.Decorator
{
    public interface IPackage
    {
        EPackageType Type { get; set; }
        int Price { get; set; }
        string ServicesIncluded { get; set; }
        int PackTime { get; set; }

        void Update();

        string ToString();

        int GetPackTime();
    }
}
