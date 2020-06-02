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
		private List<Card> cardsInHand = new List<Card>();
		public IReadOnlyList<Card> CardsInTheHand => cardsInHand.ToList().AsReadOnly();
		protected Hand(int rank)
		{
			Rank = rank;
		}

		public int Rank { get; }
		public string HandName { get; protected set; }

		public abstract Maybe<Hand> IsMatch(IEnumerable<Card> cards);

		public abstract void SetHandName();

		protected Maybe<T> CreateCopy<T>(IEnumerable<Card> handCards)
			where T : Hand
		{
			T hand = (T)Activator.CreateInstance(GetType());
			hand.SetHandCards(handCards);
			return Maybe<T>.Some(hand);
		}

		private void SetHandCards(IEnumerable<Card> handCards)
		{
			cardsInHand.Clear();
			cardsInHand.AddRange(handCards);
			SetHandName();
		}

		protected void ThrowIfDuplicate(IEnumerable<Card> cards)
		{
			HandHelper.ThrowIfDuplicate(cards);
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

		public override string ToString()
		{
			if (string.IsNullOrEmpty(HandName))
				return string.Empty;

			return HandName;
		}
	}
}
