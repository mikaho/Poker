using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Hands;
using Poker.Texas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("HandSelector")]
	public class TexasHandSelectorTests
	{
		[TestMethod]
		public void TexasHandSelectorStraight10High()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand hand = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(hand);
			Assert.AreEqual(5, hand.CardsInTheHand.Count);
			Assert.AreEqual(10, hand.CardsInTheHand[0].Value);
			Assert.AreEqual(6, hand.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, hand.Rank);
		}
	}
}
