using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Texas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	public class TexasTests
	{
		[TestMethod]
		public void TexasGameDealPlayerCards()
		{
			//Arrange
			TexasGame texasGame = Create();

			//Act
			texasGame.Deal();

			//Assert
			Assert.AreEqual(2, texasGame.Players.Count);
			Assert.AreEqual(2, texasGame.PlayerCards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[1].Cards.Count);
			Assert.AreEqual(48, texasGame.Deck.Cards.Count);
			Assert.AreEqual(3, texasGame.DealsLeft);
		}

		private static TexasGame Create()
		{
			Deck deck = new Deck();
			TexasGame texasGame = new TexasGame(deck);
			texasGame.AddPlayer(new Player("Mika"));
			texasGame.AddPlayer(new Player("Masa"));
			return texasGame;
		}

		[TestMethod]
		public void TexasGameDealPlayerCardsAAToOnePlayer()
		{
			//Arrange
			TexasGame texasGame = Create();
			texasGame.PlayerCards[0].AddCard(texasGame.Deck.PickCardFromDeck(new Card(Suits.Hearts, "A")));
			texasGame.PlayerCards[0].AddCard(texasGame.Deck.PickCardFromDeck(new Card(Suits.Dimensions, "A")));

			//Act
			texasGame.Deal();

			//Assert
			Assert.AreEqual(2, texasGame.Players.Count);
			Assert.AreEqual(2, texasGame.PlayerCards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[1].Cards.Count);
			Assert.AreEqual(48, texasGame.Deck.Cards.Count);
			PlayerCards playerCards = texasGame.PlayerCards[0];
			Assert.AreEqual(14, playerCards.Cards[0].Value);
			Assert.AreEqual(14, playerCards.Cards[1].Value);
		}

		[TestMethod]
		public void TexasGameDealFlop()
		{
			//Arrange
			TexasGame texasGame = Create();

			//Act
			texasGame.Deal();
			texasGame.Deal();

			//Assert
			Assert.AreEqual(2, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[1].Cards.Count);
			Assert.AreEqual(3, texasGame.DoardCards.Count);
			Assert.AreEqual(44, texasGame.Deck.Cards.Count);
			Assert.AreEqual(2, texasGame.DealsLeft);
		}

		[TestMethod]
		public void TexasGameDealToTheEnd()
		{
			//Arrange
			TexasGame texasGame = Create();

			//Act
			while (texasGame.HasDealLeft())
			{
				texasGame.Deal();
			}

			//Assert
			Assert.AreEqual(2, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[1].Cards.Count);
			Assert.AreEqual(5, texasGame.DoardCards.Count);
			Assert.AreEqual(52 - 12, texasGame.Deck.Cards.Count);
			Assert.AreEqual(0, texasGame.DealsLeft);
		}
	}
}
