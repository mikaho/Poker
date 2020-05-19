using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public abstract class Hand : Entity, IComparable<Hand>
	{
		private readonly Hand next;

		private List<Card> cardsInHand = new List<Card>();
		public IReadOnlyList<Card> CardsInTheHand => cardsInHand.ToList().AsReadOnly();
		public Hand(int rank, Hand next)
		{
			Rank = rank;
			this.next = next;
		}

		public int Rank { get; }

		public abstract Hand IsMatch(IEnumerable<Card> cards);

		protected void SetHandCards(IEnumerable<Card> handCards)
		{
			cardsInHand.Clear();
			cardsInHand.AddRange(handCards);
		}

		protected void ThrowIfDuplicate(IEnumerable<Card> cards)
		{
			HandHelper.ThrowIfDuplicate(cards);
		}

		protected Hand Next(IEnumerable<Card> cards)
		{
			if (next == null)
				return null;

			return next.IsMatch(cards);
		}

		public int CompareTo([NotNull] Hand other)
		{
			if (cardsInHand.Count != other.CardsInTheHand.Count)
				throw new InvalidOperationException();

			if (Rank == other.Rank)
			{
				for (int i = 0; i < cardsInHand.Count; i++)
				{
					Card card = cardsInHand[i];
					Card otherHandCard = other.CardsInTheHand[i];
					if (card.Value != otherHandCard.Value)
					{
						return card.Value.CompareTo(otherHandCard.Value);
					}
				}

				return 0; // Same hands
			}
			else
			{
				return Rank.CompareTo(other.Rank);
			}
		}
	}
}
