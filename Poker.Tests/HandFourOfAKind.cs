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
	public class HandFourOfAKind
	{
		[TestMethod]
		public void HandIsHandFourOfAKind()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 3));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 3));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			FourOfAKind h = new FourOfAKind();
			Hand fourOfAKind = h.IsMatch(cards);

			//Assert
			Assert.IsNotNull(fourOfAKind);
			Assert.AreEqual(5, fourOfAKind.CardsInTheHand.Count);
			Assert.AreEqual(14, fourOfAKind.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.FourOfAKind, fourOfAKind.Rank);
		}

		[TestMethod]
		public void HandIsNotHandFourOfAKind()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 3));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			FourOfAKind fourOfAKind = new FourOfAKind();

			//Assert
			Assert.IsNull(fourOfAKind.IsMatch(cards));
		}

		[TestMethod]
		public void HandFourOfAKindTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			FourOfAKind hand = new FourOfAKind();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
