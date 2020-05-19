using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Tests
{
	[TestClass]
	[TestCategory("Deck")]
	public class DeckTests
	{
		[TestMethod]
		public void DeckHas52Cards()
		{
			//Arrange
			Deck deck = new Deck();

			//Act

			//Assert
			Assert.AreEqual(52, deck.Cards.Count);
		}

		[TestMethod]
		public void DeckSuffleCards()
		{
			//Arrange
			Deck deck = new Deck();
			int originalSum = deck.Cards.Sum(c => c.Value);

			//Act
			IReadOnlyList<Card> originalOrder = deck.Cards;
			deck.Suffle();
			IReadOnlyList<Card> suffledOrder = deck.Cards;

			//Assert
			Assert.AreEqual(52, deck.Cards.Count);
			Assert.AreEqual(originalSum, deck.Cards.Sum(c => c.Value));
			bool allInSameOrder = true;
			foreach (Card card in originalOrder)
			{
				int index = originalOrder.ToList().IndexOf(card);
				if (card != suffledOrder[index])
				{
					allInSameOrder = false;
					break;
				}
			}
			Assert.IsFalse(allInSameOrder);
		}

		[TestMethod]
		public void DeckTakeTopMostCard()
		{
			//Arrange
			Deck deck = new Deck();

			//Act
			Card cardTaken = deck.TakeTopMostCard();

			//Assert
			Assert.AreEqual(51, deck.Cards.Count);
			Assert.IsFalse(deck.Cards.ToList().Exists(c => c == cardTaken));
		}

		[TestMethod]
		public void DeckPickCard()
		{
			//Arrange
			Deck deck = new Deck();

			//Act
			Card cardToPick = new Card(Suits.Clubes, 9);
			Card cardTaken = deck.PickCardFromDeck(cardToPick);

			//Assert
			Assert.AreEqual(cardToPick, cardTaken);
			Assert.AreEqual(51, deck.Cards.Count);
			Assert.IsFalse(deck.Cards.ToList().Exists(c => c == cardTaken));

		}

	}
}
