using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class TreeOfAKind : Hand
	{
		public TreeOfAKind(Hand next = null)
			: base(Constancts.HandRanks.ThreeOfAKind, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> threeOfAKind = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 3)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(3)
				.ToList();

			if (threeOfAKind.Count != 3)
				return Next(cards);

			List<Card> highCards = cards.ToList()
				.FindAll(c => c.Value != threeOfAKind.First().Value)
				.OrderByDescending(c => c.Value)
				.Take(2)
				.ToList();

			List<Card> finalCards = new List<Card>(threeOfAKind);
			finalCards.AddRange(highCards);
			SetHandCards(finalCards);

			return this;
		}
	}
}
