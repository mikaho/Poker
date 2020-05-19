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
	public class HandFlushTests
	{
		[TestMethod]
		public void HandIsFlush()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, 7));
			cards.Add(new Card(Suits.Hearts, 5));
			cards.Add(new Card(Suits.Hearts, "T"));
			cards.Add(new Card(Suits.Hearts, "J"));
			cards.Add(new Card(Suits.Hearts, "Q"));

			//Act
			Flush h = new Flush();
			Hand flush = h.IsMatch(cards);

			//Assert
			Assert.IsNotNull(flush);
			Assert.AreEqual(5, flush.CardsInTheHand.Count);
			Assert.AreEqual(12, flush.CardsInTheHand[0].Value);
			Assert.AreEqual(5, flush.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Flush, flush.Rank);
		}


		[TestMethod]
		public void HandIsNotFlush()
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
			Flush flush = new Flush();

			//Assert
			Assert.IsNull(flush.IsMatch(cards));
		}

		[TestMethod]
		public void HandFlushTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			Flush hand = new Flush();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
