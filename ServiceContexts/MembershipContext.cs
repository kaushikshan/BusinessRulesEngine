using BusinessRulesEngine.CoreModels;
using BusinessRulesEngine.Services;
using System;

namespace BusinessRulesEngine.ServiceContexts
{
	/// <summary>
	/// This is the context that handles Membership related Operation
	/// Seperation is useful if we have a Repository Pattern for Data Access
	/// </summary>
	class MembershipContext : IManageMembership
	{
		/// <summary>
		/// Activates the Membership
		/// </summary>
		/// <param name="membership"></param>
		/// <returns></returns>
		public string ActivateMembership(Membership membership)
		{
			//This may invlove Data Access in Real-World scenario
			membership.isActive = true;
			return "Membership Activated as : " + membership.membershipType.ToString();
		}

		/// <summary>
		/// Upgrades the Membership
		/// </summary>
		/// <param name="membership"></param>
		/// <returns></returns>
		public string UpgradeMembership(Membership membership)
		{
			string beforeUpgrade = membership.membershipType.ToString();

			//This may invlove Data Access in Real-World scenario
			membership.membershipType = (membership.membershipType == MembershipType.Silver)
														? MembershipType.Gold : MembershipType.Silver;

			return String.Format("Membership Upgraded From {0} to {1} : ", beforeUpgrade, membership.membershipType.ToString());
		}
	}
}
