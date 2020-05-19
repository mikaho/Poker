using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using Poker.Hands;
using Poker.Ranks;
using Poker.Texas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("Hand-Compare")]
	public class TexasHandCompareTests
	{
		[TestMethod]
		public void CompareStrait()
		{
			//Arrange
			List<Player> players = new List<Player>
			{
				new Player("Mika"),
				new Player("Masa")
			};

			players[0].AddCard(new Card(Suits.Clubes, 11));
			players[0].AddCard(new Card(Suits.Hearts, 9));

			players[1].AddCard(new Card(Suits.Spades, "A"));
			players[1].AddCard(new Card(Suits.Spades, "K"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, 10),
				new Card(Suits.Dimensions, 8),
				new Card(Suits.Clubes, 2),
				new Card(Suits.Clubes, 5),
				new Card(Suits.Hearts, 7)
			};

			HandCompare handCompare = new HandCompare(new TexasHandSelector());

			//Act
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(1, ranks[0].Players.Count);
			Assert.AreEqual(1, ranks[1].Players.Count);
			Assert.AreEqual(0, ranks[0].Position);
			Assert.AreEqual(1, ranks[1].Position);
			Assert.AreEqual(Constancts.HandRanks.Straight, ranks[0].Hand.Rank);
			Assert.AreEqual(Constancts.CardValues.Jack, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual(Constancts.HandRanks.HighCard, ranks[1].Hand.Rank);
			Assert.AreEqual(Constancts.CardValues.Ace, ranks[1].Hand.CardsInTheHand[0].Value);
		}
	}
}
