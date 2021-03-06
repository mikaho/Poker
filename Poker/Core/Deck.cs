﻿using Poker.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core
{
	public class Deck : Entity
	{
		private List<Card> cards = new List<Card>();
		public Deck()
		{
			CreateCards();
		}

		private void CreateCards()
		{
			foreach (Suits suit in Suits.GetAll<Suits>())
			{
				foreach (int value in Enumerable.Range(2, 13))
				{
					cards.Add(new Card(suit, value));
				}
			}
		}

		public IReadOnlyList<Card> Cards => cards.ToList().AsReadOnly();

		// Suffle
		public void Suffle()
		{
			Enumerable.Range(0, 500).ToList().ForEach(i =>
			{
				int indexToTake = new Randomizer().Next(0, Cards.Count);
				Card cardToMove = cards[indexToTake];
				cards.Remove(cardToMove);

				int indexToInsert = new Randomizer().Next(0, Cards.Count);
				cards.Insert(indexToInsert, cardToMove);
			});
		}

		// Take card from top
		public Card TakeTopMostCard()
		{
			Card cardToTake = cards.First();
			cards.Remove(cardToTake);
			return cardToTake;
		}

		public Card PickCardFromDeck(Card cardToPick)
		{
			Card cardTaken = cards.Find(c => c.Equals(cardToPick));
			cards.Remove(cardTaken);
			return cardTaken;
		}

		private class Randomizer
		{
			Random random = new Random(DateTime.Now.Millisecond * DateTime.Now.GetHashCode());
			public int Next(int min, int max)
			{
				return random.Next(min, max);
			}
		}
	}
}
