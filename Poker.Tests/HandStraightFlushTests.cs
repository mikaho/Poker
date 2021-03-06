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
	public class HandStraightFlushTests
	{
		[TestMethod]
		public void HandIsRoyalFlush()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, "Q"));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, "K"));
			cards.Add(new Card(Suits.Hearts, "T"));
			cards.Add(new Card(Suits.Hearts, "J"));

			//Act
			StraightFlush h = new StraightFlush();
			Hand straightFlush = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straightFlush);
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
		}

		[TestMethod]
		public void HandIsStraightFlush5High()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Hearts, 3));
			cards.Add(new Card(Suits.Hearts, 2));
			cards.Add(new Card(Suits.Clubes, 3));
			cards.Add(new Card(Suits.Hearts, 5));
			cards.Add(new Card(Suits.Hearts, Constancts.CardValues.Ten));
			cards.Add(new Card(Suits.Hearts, 4));
			cards.Add(new Card(Suits.Hearts, Constancts.CardValues.Ace));

			
			//Act
			StraightFlush h = new StraightFlush();
			Hand straightFlush = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straightFlush);
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
			Assert.AreEqual<int>(5, straightFlush.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(1, straightFlush.CardsInTheHand[4].Value);
			Assert.AreEqual("❤A", straightFlush.CardsInTheHand[4].ToString());
		}

		[TestMethod]
		public void HandIsStraightFlush6High()
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
			StraightFlush h = new StraightFlush();
			Hand straightFlush = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straightFlush);
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
			Assert.AreEqual<int>(6, straightFlush.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(2, straightFlush.CardsInTheHand[4].Value);
		}

		[TestMethod]
		public void HandIsStraightFlushJackHigh()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, 9));
			cards.Add(new Card(Suits.Clubes, "J"));
			cards.Add(new Card(Suits.Clubes, "T"));
			cards.Add(new Card(Suits.Clubes, "K"));
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, 8));
			cards.Add(new Card(Suits.Clubes, 7));

			//Act
			StraightFlush h = new StraightFlush();
			Hand straightFlush = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straightFlush);
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
			Assert.AreEqual<int>(11, straightFlush.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(7, straightFlush.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.StraightFlush, straightFlush.Rank);
		}

		[TestMethod]
		public void HandIsStraightFlush9High()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, 9));
			cards.Add(new Card(Suits.Clubes, 6));
			cards.Add(new Card(Suits.Clubes, 5));
			cards.Add(new Card(Suits.Clubes, "K"));
			cards.Add(new Card(Suits.Clubes, "Q"));
			cards.Add(new Card(Suits.Clubes, 8));
			cards.Add(new Card(Suits.Clubes, 7));

			//Act
			StraightFlush h = new StraightFlush();
			Hand straightFlush = h.IsMatch(cards).Value;

			//Assert
			Assert.IsNotNull(straightFlush);
			Assert.AreEqual(5, straightFlush.CardsInTheHand.Count);
			Assert.AreEqual<int>(9, straightFlush.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(5, straightFlush.CardsInTheHand[4].Value);
			Assert.AreEqual(Constancts.HandRanks.StraightFlush, straightFlush.Rank);
		}

		[TestMethod]
		public void HandIsNotStraightFlush()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, 9));
			cards.Add(new Card(Suits.Clubes, "J"));
			cards.Add(new Card(Suits.Clubes, 5));
			cards.Add(new Card(Suits.Hearts, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, 8));
			cards.Add(new Card(Suits.Clubes, 7));

			//Act
			StraightFlush straightFlush = new StraightFlush();

			//Assert
			Assert.IsFalse(straightFlush.IsMatch(cards).HasValue);
		}

		[TestMethod]
		public void HandStraightFlushTestDuplicate()
		{
			//Arrange
			List<Card> cards = new List<Card>();
			cards.Add(new Card(Suits.Clubes, "A"));
			cards.Add(new Card(Suits.Clubes, "A"));

			//Act
			StraightFlush hand = new StraightFlush();

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => hand.IsMatch(cards));
		}
	}
}
