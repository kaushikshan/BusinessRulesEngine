using BusinessRulesEngine.Services;
using System;

namespace BusinessRulesEngine.ServiceContexts
{
	/// <summary>
	/// This is the context that handles Notification related Operation
	/// Seperation is useful if we use external services such as AWS SES
	/// </summary>
	public class NotificationContext : INotify
	{
		/// <summary>
		/// Send the email
		/// </summary>
		/// <param name="email"></param>
		/// <param name="topic"></param>
		/// <returns></returns>
		public string SendEmailNotification(string email, string topic)
		{
			//May involve calling a service
			return String.Format("Email Sent to {0} About {1}", email, topic);
		}
	}
}
