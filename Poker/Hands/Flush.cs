using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Flush : Hand
	{
		public Flush(IEnumerable<Card> cards)
		: this(cards, null)
		{
		}

		public Flush(IEnumerable<Card> cards, Hand next)
			: base(Constancts.HandRanks.Flush, cards, next)
		{
		}

		public override bool IsMatch()
		{
			if (Cards.Count < 5)
				return Next();

			List<Card> cardsInSuit = Cards.GroupBy(s => s.Suit)
				.Where(g => g.Count() >= 5)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(5)
				.ToList();

			if (cardsInSuit.Count != 5)
				return Next();

			SetHandCards(cardsInSuit);

			return true;
		}

	}
}
