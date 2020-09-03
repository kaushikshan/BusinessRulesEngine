using BusinessRulesEngine.ServiceContexts;
using BusinessRulesEngine.Services;
using System.Text;

namespace BusinessRulesEngine.CoreModels
{
	/// <summary>
	/// The membership class, uses membership service
	/// </summary>
	public class Membership : VirtualProduct
	{
		public bool isActive { get; set; }
		public string email { get; set; }
		public MembershipType membershipType { get; set; }

		private IManageMembership membershipService;

		public Membership(string email) : base("MemberShip")
		{
			// Initialize the Service
			membershipService = new MembershipContext();

			//Set defaults
			this.email = email;
			this.isActive = false;
			this.membershipType = 0;
		}

		/// <summary>
		/// Called on Payment towards Activation
		/// </summary>
		/// <returns></returns>
		public virtual StringBuilder OnActivationPayment()
		{
			StringBuilder templateResult = new StringBuilder();

			//Activate only if not already
			if (!this.isActive)
			{
				//Activation may need Data Access, let the service worry about that
				templateResult.AppendLine(membershipService.ActivateMembership(this));

				//Send the email address and the context for the notification service
				templateResult.AppendLine(notifyService.SendEmailNotification(this.email, "Activation"));
			}
			else
			{
				//Already active
				templateResult.AppendLine("Membership is already Active");
			}

			return templateResult;
		}

		/// <summary>
		/// Called on Payment towards Upgradation
		/// </summary>
		/// <returns></returns>
		public virtual StringBuilder OnUpgradePayment()
		{
			StringBuilder templateResult = new StringBuilder();

			//Upgrade only if active and not Gold
			if (this.isActive && this.membershipType != MembershipType.Gold)
			{
				templateResult.AppendLine(membershipService.UpgradeMembership(this));
				templateResult.AppendLine(notifyService.SendEmailNotification(this.email, "Upgradation"));
			}
			else if (this.membershipType == MembershipType.Gold) //Nothing to upgrade
			{
				templateResult.AppendLine("Membership is already Gold");
			}
			else //Activate first
			{
				templateResult.AppendLine("Please Make the Payment For Activation Before Upgrade");
			}

			return templateResult;
		}
	}
}
