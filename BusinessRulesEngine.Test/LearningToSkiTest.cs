using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.CoreModels;
using System.Linq;

namespace BusinessRulesEngine.Test
{
	[TestClass]
	public class LearningToSkiTest
	{
		[TestMethod]
		public void SkiVideoTest()
		{
			LearningToSkiVideo skiVideo = new LearningToSkiVideo();

			var outPutList = skiVideo.OnPayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Payment Commission Generated for Product: " + skiVideo.ProductDescription);
			expectedOutPut.AppendLine("Packing Slip Generated for Product: " + skiVideo.ProductDescription);

			expectedOutPut.AppendLine("Payment Commission Generated for Product: " + "First Aid");
			expectedOutPut.AppendLine("Packing Slip Generated for Product: " + "First Aid");

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);
		}
	}
}
