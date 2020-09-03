using BusinessRulesEngine.CoreModels;
using System.Collections.Generic;

namespace BusinessRulesEngine.Services
{
	/// <summary>
	/// Contract for Payment Service
	/// </summary>
	public interface IPaymentGenerate
	{
		/// <summary>
		/// Generates Commission
		/// </summary>
		/// <param name="physicalProduct"></param>
		/// <returns></returns>
		string GenerateCommissionPayment(PhysicalProduct physicalProduct);

		/// <summary>
		/// Overload of GenerateCommissionPayment to handle multiple Physical Products
		/// </summary>
		/// <param name="physicalProduct"></param>
		/// <returns></returns>
		string GenerateCommissionPayment(IList<PhysicalProduct> physicalProduct);
	}
}
