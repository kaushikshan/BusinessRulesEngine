using BusinessRulesEngine.ServiceContexts;
using BusinessRulesEngine.Services;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.CoreModels
{
    /// <summary>
    /// This is an abstraction over the basic Product
    /// Indicates any physical product
    /// </summary>
    public abstract class PhysicalProduct : Product
    {
        //Needs slip generation and payment generation services
        protected ISlipGenerate slipGenerateService;
        private IPaymentGenerate paymentGenerateService;

        public PhysicalProduct(string productDescription) : base(productDescription)
        {
            //Initialize the services
            this.paymentGenerateService = new PaymentContext();
            this.slipGenerateService = new SlipGenerationContext();
        }

        /// <summary>
        /// Handles what is needed when a Physical Product is Paid For
        /// </summary>
        /// <returns></returns>
        public virtual StringBuilder OnPayment()
        {
            StringBuilder templateResult = new StringBuilder();
            
            //Generate Commission
            templateResult.AppendLine(paymentGenerateService.GenerateCommissionPayment(this));
            //Generate Packing slip
            templateResult.AppendLine(slipGenerateService.GeneratePackingSlip(this));

            return templateResult;
        }

        /// <summary>
        /// An overload for OnPayment is a list of Physical Products are Paid For
        /// Caters to Learning to Fly video payment case
        /// </summary>
        /// <param name="physicalProducts"></param>
        /// <returns></returns>
        public virtual StringBuilder OnPayment(List<PhysicalProduct> physicalProducts)
        {
            StringBuilder templateResult = new StringBuilder();

            //Generate Commission
            templateResult.AppendLine(paymentGenerateService.GenerateCommissionPayment(physicalProducts));
            //Generate Packing slip
            templateResult.AppendLine(slipGenerateService.GeneratePackingSlip(physicalProducts));

            return templateResult;
        }
    }
}
