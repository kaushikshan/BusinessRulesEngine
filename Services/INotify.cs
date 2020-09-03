namespace BusinessRulesEngine.Services
{
	/// <summary>
	/// Contract for notification service
	/// </summary>
	public interface INotify
	{
		/// <summary>
		/// Sends an Email
		/// </summary>
		/// <param name="email"></param>
		/// <param name="topic"></param>
		/// <returns></returns>
		string SendEmailNotification(string email, string topic);
	}
}
