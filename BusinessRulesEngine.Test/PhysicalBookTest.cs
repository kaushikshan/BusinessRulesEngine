using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessRulesEngine.CoreModels;
using System.Linq;

namespace BusinessRulesEngine.Test
{
	[TestClass]
	public class PhysicalBookTest
	{
		[TestMethod]
		public void BookTest()
		{
			Book book = new Book("Harry Potter"); 

			var outPutList = book.OnPayment().ToString().Split('\n').ToList();

			outPutList = outPutList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			outPutList = outPutList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			StringBuilder expectedOutPut = new StringBuilder();

			expectedOutPut.AppendLine("Payment Commission Generated for Product: " + book.ProductDescription);
			expectedOutPut.AppendLine("Packing Slip Generated for Product: " + book.ProductDescription);
			expectedOutPut.AppendLine("Royalty Slip Generated for Book: " + book.ProductDescription);

			var expectedList = expectedOutPut.ToString().Split('\n').ToList();

			expectedList = expectedList.Select(o => o.Replace("\n", "").Replace("\r", "")).ToList();
			expectedList = expectedList.Where(o => !String.IsNullOrEmpty(o)).ToList();

			bool testResult = (expectedList.All(e => outPutList.Contains(e))
										&& outPutList.Count == expectedList.Count);

			Assert.IsTrue(testResult);
		}
	}
}
