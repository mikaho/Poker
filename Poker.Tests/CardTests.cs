using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("Card")]
	public class CardTests
	{
		[TestMethod]
		public void CardIsAceA()
		{
			//Arrange
			Card card = new Card(Suits.Hearts, "A");

			//Act

			//Assert
			Assert.AreEqual(14, card.Value);
			Assert.AreEqual("❤A", card.ToString());
		}

		[TestMethod]
		public void CardIsAce14()
		{
			//Arrange
			Card card = new Card(Suits.Clubes, 14);

			//Act

			//Assert
			Assert.AreEqual(14, card.Value);
			Assert.AreEqual("♣A", card.ToString());
		}

		[TestMethod]
		public void CardIsAceLow()
		{
			//Arrange
			Card card = new Card(Suits.Spades, 1);

			//Act

			//Assert
			Assert.AreEqual(1, card.Value);
			Assert.AreEqual("♠A", card.ToString());
		}
	}
}
