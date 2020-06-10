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
	public class HandFullHouse
	{
		[TestMethod]
		public void HandIsFullHouse()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 3));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 7));
			cards.Add(new Card(Suits.Dimensions, "A"));

			//Act
			FullHouse h = new FullHouse();
			Hand fullHouse = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(fullHouse);
			Assert.AreEqual(5, fullHouse.CardsInTheHand.Count);
			Assert.AreEqual<int>(3, fullHouse.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(14, fullHouse.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.FullHouse, fullHouse.Rank);
		}

		[TestMethod]
		public void HandIsNotFullHouse()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, 8));
			cards.Add(new Card(Suits.Spades, 3));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 7));
			cards.Add(new Card(Suits.Dimensions, "A"));

			//Act
			FullHouse fullHouse = new FullHouse();

			//Assert
			Assert.IsFalse(fullHouse.IsMatch(cards).HasValue);
		}

		[TestMethod]
		public void HandFullHouseTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			FullHouse hand = new FullHouse();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
