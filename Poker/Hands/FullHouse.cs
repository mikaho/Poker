using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FullHouse : Hand
	{
		public FullHouse(IEnumerable<Card> cards)
			: this(cards, null)
		{
		}

		public FullHouse(IEnumerable<Card> cards, Hand next)
			: base(Constancts.HandRanks.FullHouse, cards, next)
		{
		}

		public override bool IsMatch()
		{
			if (Cards.Count < 5)
				return Next();

			List<Card> treeOfAKind = Cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 3)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(3)
				.ToList();

			if (treeOfAKind.Count != 3)
				return Next();

			List<Card> remainingCard = Cards.ToList()
				.FindAll(c => c.Value != treeOfAKind.First().Value);

			List<Card> pair = remainingCard.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 2)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(2)
				.ToList();

			if (pair.Count != 2)
				return Next();

			List<Card> cards = new List<Card>(treeOfAKind);
			cards.AddRange(pair);

			SetHandCards(cards);

			return true;
		}
	}
}
