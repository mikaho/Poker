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
	public class HandHighCard
	{
		[TestMethod]
		public void HandIsHighCard()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 7));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 6));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, 2));
			cards.Add(new Card(Suits.Hearts, 9));

			//Act
			HighCard h = new HighCard();
			Hand highCard = h.IsMatch(cards);

			//Assert
			Assert.IsNotNull(highCard);
			Assert.AreEqual(5, highCard.CardsInTheHand.Count);
			Assert.AreEqual(14, highCard.CardsInTheHand[0].Value);
			Assert.AreEqual(13, highCard.CardsInTheHand[1].Value);
			Assert.AreEqual(9, highCard.CardsInTheHand[2].Value);
			Assert.AreEqual(7, highCard.CardsInTheHand[3].Value);
			Assert.AreEqual(6, highCard.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.HighCard, highCard.Rank);
		}

		[TestMethod]
		public void HandHighCardTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			HighCard hand = new HighCard();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
