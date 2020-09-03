using System.Text;

namespace BusinessRulesEngine.CoreModels
{
	/// <summary>
	/// The Book, only aware of Royalty Slip Generation
	/// </summary>
	public class Book : PhysicalProduct
	{
		public Book(string description) : base(description)
		{
			//Nothing to do here
		}

		/// <summary>
		/// On Payment calls the Base class template method
		/// </summary>
		/// <returns></returns>
		public override StringBuilder OnPayment()
		{
			StringBuilder templateResult = new StringBuilder();

			//Do everything that is needed for Physical Products
			templateResult.AppendLine(base.OnPayment().ToString());

			//Do the Royalty Bit 
			templateResult.AppendLine(slipGenerateService.GenerateRoyaltySlip(this).ToString());

			return templateResult;
		}
	}
}
