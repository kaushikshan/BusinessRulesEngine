using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.CoreModels;
using System.Linq;

namespace BusinessRulesEngine.Test
{
	[TestClass]
	public class MembershipTest
	{
		[TestMethod]
		public void MembrshipInitializtionTest()
		{
			Membership membership = new Membership("walterwhite@cook.edu");
			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);
		}

		[TestMethod]
		public void MembrshipActivationTest()
		{
			Membership membership = new Membership("walterwhite@cook.edu");

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);

			var outPutList = membership.OnActivationPayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Membership Activated as : " + membership.membershipType.ToString());
			expectedOutPut.AppendFormat("Email Sent to {0} About {1}", membership.email, "Activation");

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);

			Assert.IsTrue(membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);
		}

		[TestMethod]
		public void MembrshipUpgradationTest()
		{
			Membership membership = new Membership("jessepinkman@cook.edu");

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);

			membership.OnActivationPayment();

			var outPutList = membership.OnUpgradePayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine(String.Format("Membership Upgraded From {0} to {1} : ", MembershipType.Bronze, membership.membershipType.ToString()));
			expectedOutPut.AppendFormat(String.Format("Email Sent to {0} About {1}", membership.email, "Upgradation"));

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);

			Assert.IsTrue(membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Silver);
		}

		[TestMethod]
		public void InvalidActivationTest()
		{
			Membership membership = new Membership("walterwhite@cook.edu");

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);

			membership.OnActivationPayment();

			var outPutList = membership.OnActivationPayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Membership is already Active");

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);

			Assert.IsTrue(membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);
		}

		[TestMethod]
		public void InvalidUpgradeTest()
		{
			Membership membership = new Membership("jessepinkman@cook.edu");

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);

			var outPutList = membership.OnUpgradePayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Please Make the Payment For Activation Before Upgrade");

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);
		}

		[TestMethod]
		public void GoldUpgradeTest()
		{
			Membership membership = new Membership("jessepinkman@cook.edu");

			Assert.IsTrue(!membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Bronze);

			membership.OnActivationPayment();
			membership.OnUpgradePayment();
			membership.OnUpgradePayment();
			var outPutList = membership.OnUpgradePayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Membership is already Gold");

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);

			Assert.IsTrue(membership.isActive);
			Assert.IsTrue(membership.membershipType == MembershipType.Gold);
		}
	}
}
