using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.CoreModels
{
	/// <summary>
	/// Video type of Product
	/// </summary>
	public class Video : PhysicalProduct
	{
		public Video(string description) : base(description)
		{

		}

		/// <summary>
		/// On Payment for a Video
		/// </summary>
		/// <returns></returns>
		public override StringBuilder OnPayment()
		{
			StringBuilder templateResult = new StringBuilder();

			//Do what we do for Physical Products
			templateResult.AppendLine(base.OnPayment().ToString());

			return templateResult;
		}

		/// <summary>
		/// Overload of OnPayment
		/// </summary>
		/// <param name="videos"></param>
		/// <returns></returns>
		public override StringBuilder OnPayment(List<PhysicalProduct> videos)
		{
			StringBuilder templateResult = new StringBuilder();

			//Do what we do for Physical Products
			templateResult.AppendLine(base.OnPayment(videos).ToString());

			return templateResult;
		}
	}
}
