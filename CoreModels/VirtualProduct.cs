using BusinessRulesEngine.ServiceContexts;
using BusinessRulesEngine.Services;

namespace BusinessRulesEngine.CoreModels
{
    /// <summary>
    /// This is an abstraction over the basic Product
    /// Indicates any virtual product
    /// </summary>
    public abstract class VirtualProduct : Product
    {
        //Need to be aware of only notification service
        protected INotify notifyService;
        public VirtualProduct(string productDescription) : base(productDescription)
        {
            //Initializes the notification service
            this.notifyService = new NotificationContext();
        }
    }
}
