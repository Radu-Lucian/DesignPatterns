using CarServiceManagement.Decorator;

namespace CarServiceManagement.Chain_Of_Responsability
{
    public class RentCarRequest
    {
        public static int LastRequestNumber;
        public int RequestNumber { get; set; }
        public IPackage SelectedPackage { get; set; }

        public RentCarRequest(IPackage rentCarPack)
        {
            RequestNumber = LastRequestNumber;
            LastRequestNumber++;
            SelectedPackage = rentCarPack;
        }

        public int GetNumberOfDays()
        {
            return SelectedPackage.PackTime();
        }
    }
}
