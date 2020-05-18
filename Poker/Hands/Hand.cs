using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public abstract class Hand
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
	}
}
