using BusinessRulesEngine.CoreModels;

namespace BusinessRulesEngine.Services
{
	/// <summary>
	/// Contract for Mambership Operations
	/// </summary>
	interface IManageMembership
	{
		/// <summary>
		/// Activates Membership
		/// </summary>
		/// <param name="membership"></param>
		/// <returns></returns>
		string ActivateMembership(Membership membership);

		/// <summary>
		/// Upgrades Membership
		/// </summary>
		/// <param name="membership"></param>
		/// <returns></returns>
		string UpgradeMembership(Membership membership);
	}
}
