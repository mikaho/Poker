using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("CardValue")]
	public class CardValueTests
	{
		[TestMethod]
		public void CardIsAceLow()
		{
			//Arrange
			CardValue cardValue = 1;

			//Act

			//Assert
			Assert.AreEqual<int>(1, cardValue);
			Assert.AreEqual("A", cardValue.ToString());
		}

		[TestMethod]
		public void CardIsAceHigh()
		{
			//Arrange
			CardValue cardValue = 14;

			//Act

			//Assert
			Assert.AreEqual<int>(14, cardValue);
			Assert.AreEqual("A", cardValue.ToString());
		}

		[TestMethod]
		public void CardIsTen()
		{
			//Arrange
			CardValue cardValue = "T";

			//Act

			//Assert
			Assert.AreEqual<int>(10, cardValue);
			Assert.AreEqual("T", cardValue.ToString());
			//Assert.AreEqual("T", cardValue.ToString());
		}
	}
}
