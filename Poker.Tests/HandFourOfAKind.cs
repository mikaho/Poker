using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
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
			FourOfAKind fourOfAKind = new FourOfAKind(cards);

			//Assert
			Assert.IsTrue(fourOfAKind.IsMatch());
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
			FourOfAKind fourOfAKind = new FourOfAKind(cards);

			//Assert
			Assert.IsFalse(fourOfAKind.IsMatch());
		}
	}
}
