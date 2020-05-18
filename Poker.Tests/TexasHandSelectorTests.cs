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
			Hand straight = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(straight);
			Assert.AreEqual(5, straight.CardsInTheHand.Count);
			Assert.AreEqual(10, straight.CardsInTheHand[0].Value);
			Assert.AreEqual(6, straight.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, straight.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorFlush()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand flush = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(flush.IsMatch(cards));
			Assert.AreEqual(5, flush.CardsInTheHand.Count);
			Assert.AreEqual(12, flush.CardsInTheHand[0].Value);
			Assert.AreEqual(5, flush.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.Flush, flush.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorFourOfAKind()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand fourOfAKind = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(fourOfAKind.IsMatch(cards));
			Assert.AreEqual(5, fourOfAKind.CardsInTheHand.Count);
			Assert.AreEqual(14, fourOfAKind.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.FourOfAKind, fourOfAKind.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorFullHouse()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand fullHouse = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(fullHouse.IsMatch(cards));
			Assert.AreEqual(5, fullHouse.CardsInTheHand.Count);
			Assert.AreEqual(3, fullHouse.CardsInTheHand[0].Value);
			Assert.AreEqual(14, fullHouse.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.FullHouse, fullHouse.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorHighCard()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand highCard = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(highCard.IsMatch(cards));
			Assert.AreEqual(5, highCard.CardsInTheHand.Count);
			Assert.AreEqual(14, highCard.CardsInTheHand[0].Value);
			Assert.AreEqual(13, highCard.CardsInTheHand[1].Value);
			Assert.AreEqual(9, highCard.CardsInTheHand[2].Value);
			Assert.AreEqual(7, highCard.CardsInTheHand[3].Value);
			Assert.AreEqual(6, highCard.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.HighCard, highCard.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorPair()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand pair = handSelector.SelectBest(cards);

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
		public void TexasHandSelectorStraightFlush6High()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Hearts, 5));
			cards.Add(new Card(Suits.Hearts, 4));
			cards.Add(new Card(Suits.Hearts, 6));

			//Act
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand straightFlush = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(straightFlush.IsMatch(cards));
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
			Assert.AreEqual(6, straightFlush.CardsInTheHand[0].Value);
			Assert.AreEqual(2, straightFlush.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.StraightFlush, straightFlush.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorTreeOfAKind()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand threeOfAKind = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(threeOfAKind.IsMatch(cards));
			Assert.AreEqual(5, threeOfAKind.CardsInTheHand.Count);
			Assert.AreEqual(14, threeOfAKind.CardsInTheHand[3].Value);
			Assert.AreEqual(13, threeOfAKind.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.ThreeOfAKind, threeOfAKind.Rank);
		}

		[TestMethod]
		public void TexasHandSelectorTwoPairs()
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
			TexasHandSelector handSelector = new TexasHandSelector();
			Hand twoPairs = handSelector.SelectBest(cards);

			//Assert
			Assert.IsNotNull(twoPairs.IsMatch(cards));
			Assert.AreEqual(5, twoPairs.CardsInTheHand.Count);
			Assert.AreEqual(3, twoPairs.CardsInTheHand[0].Value);
			Assert.AreEqual(2, twoPairs.CardsInTheHand[2].Value);
			Assert.AreEqual(14, twoPairs.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.TwoPairs, twoPairs.Rank);
		}
	}
}
