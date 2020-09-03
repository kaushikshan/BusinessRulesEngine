using BusinessRulesEngine.CoreModels;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.Services
{
	/// <summary>
	/// This is the context that handles Notification related Operation
	/// Seperation is useful if we use external APIs for Real Time Payments
	/// </summary>
	public class PaymentContext : IPaymentGenerate
	{
		/// <summary>
		/// This may have a seperate logic about specific Products
		/// </summary>
		/// <param name="physicalProduct"></param>
		/// <returns></returns>
		public string GenerateCommissionPayment(PhysicalProduct physicalProduct)
		{
			return "Payment Commission Generated for Product: " + physicalProduct.ProductDescription;
		}


		/// <summary>
		/// Overload of GenerateCommissionPayment to handle multiple Physical Products
		/// </summary>
		/// <param name="physicalProducts"></param>
		/// <returns></returns>
		public string GenerateCommissionPayment(IList<PhysicalProduct> physicalProducts)
		{

			StringBuilder resultBuilder = new StringBuilder();

			foreach (PhysicalProduct physicalProduct in physicalProducts)
			{
				resultBuilder.AppendLine("Payment Commission Generated for Product: " + physicalProduct.ProductDescription);
			}
			return resultBuilder.ToString();
		}
	}
}
