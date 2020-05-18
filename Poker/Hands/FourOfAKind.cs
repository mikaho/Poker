using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FourOfAKind : Hand
	{
		public FourOfAKind(Hand next = null)
			: base(Constancts.HandRanks.FourOfAKind, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> fourOfAKind = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 4)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(4)
				.ToList();

			if (fourOfAKind.Count != 4)
				return Next(cards);

			Card highCard = cards.ToList()
				.FindAll(c => c.Value != fourOfAKind.First().Value)
				.OrderByDescending(c => c.Value)
				.First();

			List<Card> finalCards = new List<Card>(fourOfAKind);
			finalCards.Add(highCard);
			SetHandCards(finalCards);

			return this;
		}
	}
}
