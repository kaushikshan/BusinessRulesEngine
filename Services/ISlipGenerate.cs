using BusinessRulesEngine.CoreModels;
using System.Collections.Generic;

namespace BusinessRulesEngine.Services
{
	/// <summary>
	/// Contract for Slip Generation Service
	/// </summary>
	public interface ISlipGenerate
	{
		/// <summary>
		/// Generate Packing Slip
		/// </summary>
		/// <param name="physicalProducts"></param>
		/// <returns></returns>
		string GeneratePackingSlip(PhysicalProduct physicalProducts);

		/// <summary>
		/// Generate Royalty Slip
		/// </summary>
		/// <param name="physicalProducts"></param>
		/// <returns></returns>
		string GenerateRoyaltySlip(Book physicalProducts);

		/// <summary>
		/// Overload of GeneratePackingSlip for multiple PhysicalProducts
		/// </summary>
		/// <param name="physicalProducts"></param>
		/// <returns></returns>
		string GeneratePackingSlip(IList<PhysicalProduct> physicalProducts);

		/// <summary>
		/// Overload of GenerateRoyaltySlip for multiple PhysicalProducts
		/// </summary>
		/// <param name="physicalProducts"></param>
		/// <returns></returns>
		string GenerateRoyaltySlip(IList<Book> physicalProducts);
	}
}
