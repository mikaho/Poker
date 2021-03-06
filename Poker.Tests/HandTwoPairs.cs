﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("Hand")]
	public class HandTwoPairs
	{
		[TestMethod]
		public void HandIsTwoPairs()
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
			TwoPairs h = new TwoPairs();
			Hand twoPairs = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(twoPairs);
			Assert.AreEqual(5, twoPairs.CardsInTheHand.Count);
			Assert.AreEqual<int>(3, twoPairs.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(2, twoPairs.CardsInTheHand[2].Value);
			Assert.AreEqual<int>(14, twoPairs.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.TwoPairs, twoPairs.Rank);
		}

		[TestMethod]
		public void HandIsNotTwoPairs()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Spades, 4));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Dimensions, "K"));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			TwoPairs twoPairs = new TwoPairs();

			//Assert
			Assert.IsFalse(twoPairs.IsMatch(cards).HasValue);
		}

		[TestMethod]
		public void HandTwoPairsTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			TwoPairs hand = new TwoPairs();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
