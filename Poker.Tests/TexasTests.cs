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
	[TestCategory("Texas")]
	public class TexasTests
	{
		[TestMethod]
		public void TexasGameDealPlayerCards()
		{
			//Arrange
			TexasGame texasGame = TexasGameHelper.Create();

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

		

		[TestMethod]
		public void TexasGameDealPlayerCardsAAToOnePlayer()
		{
			//Arrange
			TexasGame texasGame = TexasGameHelper.Create();
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
			TexasGame texasGame = TexasGameHelper.Create();

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
			TexasGame texasGame = TexasGameHelper.Create();

			//Act
			DealToTheEnd(texasGame);

			//Assert
			Assert.AreEqual(2, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(2, texasGame.PlayerCards[1].Cards.Count);
			Assert.AreEqual(5, texasGame.DoardCards.Count);
			Assert.AreEqual(52 - 12, texasGame.Deck.Cards.Count);
			Assert.AreEqual(0, texasGame.DealsLeft);
		}

		private static void DealToTheEnd(TexasGame texasGame)
		{
			while (texasGame.HasDealLeft())
			{
				texasGame.Deal();
			}
		}
	}
}
