using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("Hand")]
	public class HandTwoPairs
	{
		[TestMethod]
		public void HandIsTwoPairs()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 3));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 2));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			TwoPairs threeOfAKind = new TwoPairs();

			//Assert
			Assert.IsNotNull(threeOfAKind.IsMatch(cards));
			Assert.AreEqual(5, threeOfAKind.CardsInTheHand.Count);
			Assert.AreEqual(3, threeOfAKind.CardsInTheHand[0].Value);
			Assert.AreEqual(2, threeOfAKind.CardsInTheHand[2].Value);
			Assert.AreEqual(14, threeOfAKind.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.TwoPairs, threeOfAKind.Rank);
		}

		[TestMethod]
		public void HandIsNotTwoPairs()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, "K"));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			TwoPairs threeOfAKind = new TwoPairs();

			//Assert
			Assert.IsNull(threeOfAKind.IsMatch(cards));
		}

		[TestMethod]
		public void HandTwoPairsTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			TwoPairs hand = new TwoPairs();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
