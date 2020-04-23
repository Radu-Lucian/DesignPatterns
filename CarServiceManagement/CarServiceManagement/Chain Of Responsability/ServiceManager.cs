namespace CarServiceManagement.Chain_Of_Responsability
{
    public class ServiceManager : UserRequest
    {
        public ServiceManager(UserRequest serviceWorker = null) : base(serviceWorker)
        {
        }

        public override int GetMaxDaysCanApprove()
        {
            return 8;
        }
    }
}
