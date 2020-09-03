using System.Collections.Generic;
using System.Text;

namespace BusinessRulesEngine.CoreModels
{
	/// <summary>
	/// The specific LearningToSki video
	/// </summary>
	public class LearningToSkiVideo : Video
	{
		//This is mandatory
		private Video firstAid;
		public LearningToSkiVideo() : base("Learning To Ski")
		{
			//Initialize the First Aid video
			firstAid = new Video("First Aid");
		}

		/// <summary>
		/// On Payment calls the base class template method
		/// </summary>
		/// <returns></returns>
		public override StringBuilder OnPayment()
		{
			StringBuilder templateResult = new StringBuilder();

			//Send the list of multiple videos
			List<PhysicalProduct> videos = new List<PhysicalProduct> { this, this.firstAid };

			//Do what we do for any physical products
			templateResult.AppendLine(base.OnPayment(videos).ToString());

			return templateResult;
		}

	}
}
