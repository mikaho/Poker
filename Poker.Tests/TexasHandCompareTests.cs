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
			TexasGame texasGame = TexasGameHelper.Create();
			HandCompare handCompare = new HandCompare(texasGame.HandSelector);

			//Act
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(texasGame.PlayerCards, texasGame.DoardCards);

			//Assert
			Assert.AreEqual(5, texasGame.PlayerCards[0].Cards.Count);
			Assert.AreEqual(5, texasGame.PlayerCards[1].Cards.Count);
		}
	}
}
