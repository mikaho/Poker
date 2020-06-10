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
		public void CompareStraitToHighCard()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, 11),
				new Card(Suits.Hearts, 9));
			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Spades, "A"),
				new Card(Suits.Spades, "K"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, 10),
				new Card(Suits.Dimensions, 8),
				new Card(Suits.Clubes, 2),
				new Card(Suits.Clubes, 5),
				new Card(Suits.Hearts, 7)
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(1, ranks[0].Players.Count);
			Assert.AreEqual(1, ranks[1].Players.Count);
			Assert.AreEqual(1, ranks[0].Position);
			Assert.AreEqual(2, ranks[1].Position);
			Assert.AreEqual(Constancts.HandRanks.Straight, ranks[0].Hand.Rank);
			Assert.AreEqual<int>(Constancts.CardValues.Jack, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual(Constancts.HandRanks.HighCard, ranks[1].Hand.Rank);
			Assert.AreEqual<int>(Constancts.CardValues.Ace, ranks[1].Hand.CardsInTheHand[0].Value);
		}


		[TestMethod]
		public void CompareStraitToFullHouseCard()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "J"),
				new Card(Suits.Hearts, 9));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Spades, "A"),
				new Card(Suits.Spades, "K"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, "Q"),
				new Card(Suits.Dimensions, "T"),
				new Card(Suits.Clubes, "A"),
				new Card(Suits.Clubes, "K"),
				new Card(Suits.Hearts, "K")
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(1, ranks[0].Players.Count);
			Assert.AreEqual(1, ranks[1].Players.Count);
			Assert.AreEqual(Constancts.HandRanks.FullHouse, ranks[0].Hand.Rank);
			Assert.AreEqual<int>(Constancts.CardValues.King, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual(Constancts.HandRanks.Straight, ranks[1].Hand.Rank);
			Assert.AreEqual<int>(Constancts.CardValues.Ace, ranks[1].Hand.CardsInTheHand[0].Value);
		}

		[TestMethod]
		public void TwoPlayersHaveingFourOfAKind()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "J"),
				new Card(Suits.Hearts, 9));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Spades, "J"),
				new Card(Suits.Spades, "K"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, 2),
				new Card(Suits.Clubes, 2),
				new Card(Suits.Hearts, 2),
				new Card(Suits.Spades, 2),
				new Card(Suits.Hearts, "A")
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(1, ranks.Count);
			Assert.AreEqual(2, ranks[0].Players.Count);
			Assert.AreEqual(Constancts.HandRanks.FourOfAKind, ranks[0].Hand.Rank);
			Assert.AreEqual<int>(2, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(Constancts.CardValues.Ace, ranks[0].Hand.CardsInTheHand[4].Value);
		}

		[TestMethod]
		public void TwoPlayersHaveingTwoPairs()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "J"),
				new Card(Suits.Hearts, "J"));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Dimensions, "K"),
				new Card(Suits.Spades, "K"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, 2),
				new Card(Suits.Clubes, 2),
				new Card(Suits.Hearts, 5),
				new Card(Suits.Spades, 5),
				new Card(Suits.Hearts, 9)
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(2, ranks.Count);
			Assert.AreEqual(Constancts.HandRanks.TwoPairs, ranks[0].Hand.Rank);
			Assert.AreEqual(Constancts.HandRanks.TwoPairs, ranks[1].Hand.Rank);
			Assert.AreEqual<int>(13, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(5, ranks[0].Hand.CardsInTheHand[2].Value);
			Assert.AreEqual<int>(9, ranks[0].Hand.CardsInTheHand[4].Value);
			Assert.AreEqual<int>(11, ranks[1].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(5, ranks[1].Hand.CardsInTheHand[2].Value);
			Assert.AreEqual<int>(9, ranks[1].Hand.CardsInTheHand[4].Value);
		}

		[TestMethod]
		public void TwoPlayersHaveingSharedPairHighCardWins()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "A"),
				new Card(Suits.Hearts, "J"));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Dimensions, "K"),
				new Card(Suits.Spades, "J"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Dimensions, 2),
				new Card(Suits.Clubes, 7),
				new Card(Suits.Hearts, 5),
				new Card(Suits.Spades, 7),
				new Card(Suits.Hearts, 9)
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(2, ranks.Count);
			Assert.AreEqual(Constancts.HandRanks.Pair, ranks[0].Hand.Rank);
			Assert.AreEqual(Constancts.HandRanks.Pair, ranks[1].Hand.Rank);
			Assert.AreEqual<int>(7, ranks[0].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(14, ranks[0].Hand.CardsInTheHand[2].Value);
			Assert.AreEqual<int>(7, ranks[1].Hand.CardsInTheHand[0].Value);
			Assert.AreEqual<int>(13, ranks[1].Hand.CardsInTheHand[2].Value);
		}

		[TestMethod]
		public void ThreePlayersDrawsBoardCardsWins()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers(3);
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "A"),
				new Card(Suits.Clubes, "J"));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Dimensions, "K"),
				new Card(Suits.Spades, "J"));

			TestHelper.AddCardsToPlayer(players, "Pirkko",
				new Card(Suits.Dimensions, "Q"),
				new Card(Suits.Spades, "T"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Hearts, 2),
				new Card(Suits.Hearts, "T"),
				new Card(Suits.Hearts, 5),
				new Card(Suits.Hearts, 7),
				new Card(Suits.Hearts, 9)
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());
			IReadOnlyList<HandRank> ranks = handCompare.RankPlayerHands(players, doardCards);

			//Assert
			Assert.AreEqual(1, ranks.Count);
			Assert.AreEqual(3, ranks[0].Players.Count);
			Assert.AreEqual(Constancts.HandRanks.Flush, ranks[0].Hand.Rank);
			Assert.AreEqual<int>(10, ranks[0].Hand.CardsInTheHand[0].Value);
		}

		[TestMethod]
		public void HandCompareThrowsExceptionWhenDuplicateCards()
		{
			//Arrange
			List<Player> players = TestHelper.CreatePlayers();
			TestHelper.AddCardsToPlayer(players, "Mika",
				new Card(Suits.Clubes, "A"),
				new Card(Suits.Clubes, "J"));

			TestHelper.AddCardsToPlayer(players, "Masa",
				new Card(Suits.Dimensions, "K"),
				new Card(Suits.Clubes, "J"));

			List<Card> doardCards = new List<Card>
			{
				new Card(Suits.Hearts, 2),
				new Card(Suits.Hearts, "T"),
				new Card(Suits.Hearts, 5),
				new Card(Suits.Hearts, 7),
				new Card(Suits.Hearts, 9)
			};

			//Act
			HandCompare handCompare = new HandCompare(new TexasHandSelector());

			//Assert
			Assert.ThrowsException<InvalidOperationException>(() => handCompare.RankPlayerHands(players, doardCards));
		}
	}
}
