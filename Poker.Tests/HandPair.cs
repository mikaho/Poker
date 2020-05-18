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
	public class HandPair
	{
		[TestMethod]
		public void HandIsPair()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 7));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 7));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 2));
			cards.Add(new Card(Suits.Hearts, 9));

			//Act
			Pair pair = new Pair();

			//Assert
			Assert.IsNotNull(pair.IsMatch(cards));
			Assert.AreEqual(5, pair.CardsInTheHand.Count);
			Assert.AreEqual(7, pair.CardsInTheHand[0].Value);
			Assert.AreEqual(7, pair.CardsInTheHand[1].Value);
			Assert.AreEqual(14, pair.CardsInTheHand[2].Value);
			Assert.AreEqual(13, pair.CardsInTheHand[3].Value);
			Assert.AreEqual(9, pair.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Pair, pair.Rank);
		}

		[TestMethod]
		public void HandIsNotPair()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, 9));
			cards.Add(new Card(Suits.Dimensions, "K"));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			Pair pair = new Pair();

			//Assert
			Assert.IsNull(pair.IsMatch(cards));
		}

		[TestMethod]
		public void HandTwoPairsTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			Pair hand = new Pair();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
