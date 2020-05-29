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
	public class HandTreeOfAKind
	{
		[TestMethod]
		public void HandIsHandTreeOfAKind()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 3));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 3));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			TreeOfAKind h = new TreeOfAKind();
			Hand threeOfAKind = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(threeOfAKind);
			Assert.AreEqual(5, threeOfAKind.CardsInTheHand.Count);
			Assert.AreEqual(14, threeOfAKind.CardsInTheHand[3].Value);
			Assert.AreEqual(13, threeOfAKind.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.ThreeOfAKind, threeOfAKind.Rank);
		}

		[TestMethod]
		public void HandIsNotTreeOfAKind()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, "K"));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			TreeOfAKind threeOfAKind = new TreeOfAKind();

			//Assert
			Assert.IsFalse(threeOfAKind.IsMatch(cards).HasValue);
		}

		[TestMethod]
		public void HandFourOfAKindTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			TreeOfAKind hand = new TreeOfAKind();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
