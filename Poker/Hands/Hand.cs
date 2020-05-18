using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public abstract class Hand
	{
		private readonly IEnumerable<Card> cards;
		private readonly Hand next;

		public IReadOnlyList<Card> Cards => cards.ToList().AsReadOnly();
		private List<Card> cardsInHand = new List<Card>();
		public IReadOnlyList<Card> CardsInTheHand => cardsInHand.ToList().AsReadOnly();
		public Hand(int rank, IEnumerable<Card> cards, Hand next)
		{
			var duplicates = cards.GroupBy(s => new { s.Suit, s.Value})
				.SelectMany(grp => grp.Skip(1));

			if (duplicates.Any())
				throw new InvalidOperationException();
			
			Rank = rank;
			this.cards = cards;
			this.next = next;
		}

		public int Rank { get; }

		public abstract bool IsMatch();
		protected void SetHandCards(IEnumerable<Card> handCards)
		{
			cardsInHand.Clear();
			cardsInHand.AddRange(handCards);
		}

		protected bool Next()
		{
			if (next == null)
				return false;

			return next.Next();
		}
	}
}
