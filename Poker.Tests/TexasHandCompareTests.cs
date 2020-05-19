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
			Assert.Inconclusive("Homma kesken");

			//Arrange
			//List<PlayerCards> playerCards = new List<PlayerCards>
			//{
			//	new PlayerCards(new Player("Mika")),
			//	new PlayerCards(new Player("Masa"))
			//};
			//playerCards[0].AddCard(new Card(Suits.Clubes, 11));
			//playerCards[0].AddCard(new Card(Suits.Hearts, 9));

			//playerCards[0].AddCard(new Card(Suits.Spades, "A"));
			//playerCards[0].AddCard(new Card(Suits.Spades, "K"));

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
			//IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(playerCards, doardCards);

			//Assert
			//Assert.AreEqual(5, ranks.PlayerCards[0].Cards.Count);
			//Assert.AreEqual(5, texasGame.PlayerCards[1].Cards.Count);
		}
	}
}
