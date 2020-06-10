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
	public class HandStraight
	{
		[TestMethod]
		public void HandIsStraight10High()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Hearts, 6));
			cards.Add(new Card(Suits.Dimensions, 7));
			cards.Add(new Card(Suits.Spades, 8));
			cards.Add(new Card(Suits.Clubes, "T"));
			cards.Add(new Card(Suits.Hearts, 9));
			cards.Add(new Card(Suits.Hearts, "Q"));

			//Act
			Straight h = new Straight();
			Hand straight = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straight);
			Assert.AreEqual(5, straight.CardsInTheHand.Count);
			Assert.AreEqual<int>(10, straight.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(6, straight.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, straight.Rank);
		}

		[TestMethod]
		public void HandIsStraightAceHigh()
		{
			//Arrange
			List<Card> cards = new List<Card>()
			{
				new Card(Suits.Clubes, "J"),
				new Card(Suits.Hearts, 9),
				new Card(Suits.Dimensions, "Q"),
				new Card(Suits.Dimensions, "T"),
				new Card(Suits.Clubes, "A"),
				new Card(Suits.Clubes, "K"),
				new Card(Suits.Hearts, "K")
			};

			//Act
			Straight h = new Straight();
			Hand straight = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straight);
			Assert.AreEqual(5, straight.CardsInTheHand.Count);
			Assert.AreEqual<int>(14, straight.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(10, straight.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, straight.Rank);
		}

		[TestMethod]
		public void HandIsNotStraight()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, 9));
			cards.Add(new Card(Suits.Spades, "J"));
			cards.Add(new Card(Suits.Clubes, 5));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, "A"));
			cards.Add(new Card(Suits.Clubes, 8));
			cards.Add(new Card(Suits.Dimensions, 7));

			//Act
			Straight straight = new Straight();

			//Assert
			Assert.IsFalse(straight.IsMatch(cards).HasValue);
		}

		[TestMethod]
		public void HandIsStraight9HighIncude8Pair()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Hearts, 6));
			cards.Add(new Card(Suits.Dimensions, 7));
			cards.Add(new Card(Suits.Spades, 8));
			cards.Add(new Card(Suits.Clubes, 8));
			cards.Add(new Card(Suits.Hearts, 9));
			cards.Add(new Card(Suits.Hearts, 5));

			//Act
			Straight h = new Straight();
			Hand straight = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straight);
			Assert.AreEqual(5, straight.CardsInTheHand.Count);
			Assert.AreEqual<int>(9, straight.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(5, straight.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, straight.Rank);
		}

		[TestMethod]
		public void HandIsStraight6HighIncudeTwoPairs()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, 2));
			cards.Add(new Card(Suits.Hearts, 6));
			cards.Add(new Card(Suits.Dimensions, 3));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 4));
			cards.Add(new Card(Suits.Hearts, 5));
			cards.Add(new Card(Suits.Hearts, 2));

			//Act
			Straight h = new Straight();
			Hand straight = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straight);
			Assert.AreEqual(5, straight.CardsInTheHand.Count);
			Assert.AreEqual<int>(6, straight.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(2, straight.CardsInTheHand[4].Value);
		}

		[TestMethod]
		public void HandStraightTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			Straight straight = new Straight();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => straight.IsMatch(cards));
		}
	}
}
