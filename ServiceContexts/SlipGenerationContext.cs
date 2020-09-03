using BusinessRulesEngine.CoreModels;
using BusinessRulesEngine.Services;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.ServiceContexts
{
	/// <summary>
	/// This is the context that handles Slip related Operation
	/// Seperation is useful if we use external services such as AWS S3
	/// To retrieve multiple templates
	/// </summary>
	public class SlipGenerationContext : ISlipGenerate
	{
		/// <summary>
		/// Generates a royalty slip
		/// May have a different template
		/// </summary>
		/// <param name="book"></param>
		/// <returns></returns>
		public string GenerateRoyaltySlip(Book book)
		{
			return "Royalty Slip Generated for Book: " + book.ProductDescription;
		}

		/// <summary>
		/// Generates a packing slip
		/// May have a different template
		/// </summary>
		/// <param name="physicalProduct"></param>
		/// <returns></returns>
		public string GeneratePackingSlip(PhysicalProduct physicalProduct)
		{
			return "Packing Slip Generated for Product: " + physicalProduct.ProductDescription;
		}

		/// <summary>
		/// Overload of GenerateRoyaltySlip to handle multiple books
		/// </summary>
		/// <param name="books"></param>
		/// <returns></returns>
		public string GenerateRoyaltySlip(IList<Book> books)
		{
			StringBuilder resultBuilder = new StringBuilder();

			foreach (Book book in books)
			{
				resultBuilder.AppendLine("Royalty Slip Generated for Book: " + book.ProductDescription);
			}
			return resultBuilder.ToString();
		}

		public string GeneratePackingSlip(IList<PhysicalProduct> physicalProducts)
		{

			StringBuilder resultBuilder = new StringBuilder();

			foreach (PhysicalProduct physicalProduct in physicalProducts)
			{
				resultBuilder.AppendLine("Packing Slip Generated for Product: " + physicalProduct.ProductDescription);
			}
			return resultBuilder.ToString();
		}
	}
}
