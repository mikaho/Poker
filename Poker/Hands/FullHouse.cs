using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FullHouse : Hand
	{
		public FullHouse(Hand next = null)
			: base(Constancts.HandRanks.FullHouse, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> treeOfAKind = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 3)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(3)
				.ToList();

			if (treeOfAKind.Count != 3)
				return Next(cards);

			List<Card> remainingCard = cards.ToList()
				.FindAll(c => c.Value != treeOfAKind.First().Value);

			List<Card> pair = remainingCard.GroupBy(s => s.Value)
				.Where(g => g.Count() == 2)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(2)
				.ToList();

			if (pair.Count != 2)
				return Next(cards);

			List<Card> finalCards = new List<Card>(treeOfAKind);
			finalCards.AddRange(pair);

			SetHandCards(finalCards);

			return this;
		}
	}
}
