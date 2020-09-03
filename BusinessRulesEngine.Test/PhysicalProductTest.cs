using System;
using System.Linq;
using System.Text;
using BusinessRulesEngine.CoreModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessRulesEngine.Test
{
	[TestClass]
	public class PhysicalProductTest
	{
		[TestMethod]
		public void VideoTest()
		{
			Video video = new Video("Game Of Thrones");

			var outPutList = video.OnPayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Payment Commission Generated for Product: " + video.ProductDescription);
			expectedOutPut.AppendLine("Packing Slip Generated for Product: " + video.ProductDescription);			

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);
		}
	}
}
