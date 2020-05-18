using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Pair : Hand
	{
		public Pair(Hand next = null)
			: base(Constancts.HandRanks.Pair, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> pair = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 2)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(2)
				.ToList();

			if (pair.Count != 2)
				return Next(cards);

			List<Card> highCards = cards.ToList()
				.FindAll(c => c.Value != pair.First().Value)
				.OrderByDescending(c => c.Value)
				.Take(3)
				.ToList();

			List<Card> finalCards = new List<Card>(pair);
			finalCards.AddRange(highCards);
			SetHandCards(finalCards);

			return this;
		}
	}
}
