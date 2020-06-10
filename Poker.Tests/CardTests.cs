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
			Assert.AreEqual<int>(14, card.Value);
			Assert.AreEqual("❤A", card.ToString());
		}

		[TestMethod]
		public void CardIsAce14()
		{
			//Arrange
			Card card = new Card(Suits.Clubes, 14);

			//Act

			//Assert
			Assert.AreEqual<int>(14, card.Value);
			Assert.AreEqual("♣A", card.ToString());
		}

		[TestMethod]
		public void CardIsAceLow()
		{
			//Arrange
			Card card = new Card(Suits.Spades, 1);

			//Act

			//Assert
			Assert.AreEqual<int>(1, card.Value);
			Assert.AreEqual("♠A", card.ToString());
		}

		[TestMethod]
		public void CardAceFromSymbol()
		{
			//Arrange
			Card card = Card.FromSuitAndValue("♠A");

			//Act

			//Assert
			Assert.AreEqual<int>(14, card.Value);
			Assert.AreEqual(Suits.Spades, card.Suit);
			Assert.AreEqual<string>("♠A", card);
		}

		[TestMethod]
		public void CardJacksFromString()
		{
			//Arrange
			Card card = "♦J";

			//Act

			//Assert
			Assert.AreEqual<int>(11, card.Value);
			Assert.AreEqual(Suits.Dimensions, card.Suit);
			Assert.AreEqual<string>("♦J", card);
		}

		[TestMethod]
		public void CardAreSame()
		{
			//Arrange
			Card card1 = "♦J";
			Card card2 = "♦J";

			//Act
			bool areSame = card1 == card2;

			//Assert
			Assert.IsTrue(areSame);
		}

		[TestMethod]
		public void CardAreNotSame()
		{
			//Arrange
			Card card1 = "♦J";
			Card card2 = "❤J";

			//Act
			bool areNotSame = card1 != card2;

			//Assert
			Assert.IsTrue(areNotSame);
		}

		[TestMethod]
		public void CardAreNotSameByValue()
		{
			//Arrange
			Card card1 = "❤J";
			Card card2 = "❤T";

			//Act
			bool areNotSame = card1 != card2;

			//Assert
			Assert.IsTrue(areNotSame);
		}

		[TestMethod]
		public void CardIsInvalueByValue()
		{
			//Arrange
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Card card1 = "❤X"; });
		}

		[TestMethod]
		public void CardIsInvalueBySuits()
		{
			//Arrange
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Card card1 = "#T"; });
		}
	}
}
