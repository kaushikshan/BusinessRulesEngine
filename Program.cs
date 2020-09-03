using BusinessRulesEngine.CoreModels;
using System;

namespace BusinessRulesEngine
{
	class Program
	{
		static void Main(string[] args)
		{
			//If the payment is for a physical product, generate a packing slip for shipping.
			//If the payment is for a book, create a duplicate packing slip for the royalty department.
			//If the payment is for a physical product or a book, generate a commission payment to the agent.
			Book book = new Book("Shantaram"); //New Book
			Console.WriteLine(book.OnPayment().ToString().Trim()); //Payment Received

			Console.WriteLine("------------------------------------------------------------------");

			//If the payment is for the video "Learning to Ski" add a free "First Aid" video to the packing slip
			//(the result of a court decision in 1997).
			//If the payment is for a physical product or a book, generate a commission payment to the agent.
			LearningToSkiVideo video = new LearningToSkiVideo(); //Learning to Ski
			Console.WriteLine(video.OnPayment().ToString().Trim()); //Payment Received

			Console.WriteLine("------------------------------------------------------------------");

			//If the payment is for a membership, activate that membership.
			//If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
			//If the payment is an upgrade to a membership, apply the upgrade.
			Membership membership = new Membership("shantaram@nomail.nil"); //New Membership
			Console.WriteLine(membership.OnActivationPayment().ToString().Trim()); //Payment Received for Activation
			Console.WriteLine(membership.OnUpgradePayment().ToString().Trim()); //Payment Received for Upgradation
		}
	}
}
