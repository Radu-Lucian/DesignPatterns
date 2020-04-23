using CarServiceManagement.Logging;
using System;

namespace CarServiceManagement.Chain_Of_Responsability
{
    public class UserRequest
    {
        public UserRequest ServiceWorker;

        public UserRequest(UserRequest serviceWorker)
        {
            ServiceWorker = serviceWorker;
        }

        public void ApplyCarRentalRequest(RentCarRequest request)
        {
            if (ApproveRequest(request))
            {
                Console.WriteLine("Request for car rental was accepted!");
                Logger.Instance.LogOk("Request processed succesfully");
            }
            else if (ServiceWorker != null)
            {
                Logger.Instance.LogOk("Car sent to another worker");
                ServiceWorker.ApplyCarRentalRequest(request);
            }
        }

        protected bool ApproveRequest(RentCarRequest request)
        {
            return request.GetNumberOfDays() <= GetMaxDaysCanApprove();
        }

        public virtual int GetMaxDaysCanApprove()
        {
            return 0;
        }
    }
}
