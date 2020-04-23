namespace CarServiceManagement.Chain_Of_Responsability
{
    public class ServiceEmployee : UserRequest
    {
        public ServiceEmployee(UserRequest serviceWorker) : base(serviceWorker)
        {
        }

        public override int GetMaxDaysCanApprove()
        {
            return 5;
        }
    }
}
