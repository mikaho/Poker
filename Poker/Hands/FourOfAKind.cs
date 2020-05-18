using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FourOfAKind : Hand
	{
		public FourOfAKind(IEnumerable<Card> cards)
			: this(cards, null)
		{
		}

		public FourOfAKind(IEnumerable<Card> cards, Hand next)
			: base(Constancts.HandRanks.FourOfAKind, cards, next)
		{
		}

		public override bool IsMatch()
		{
			if (Cards.Count < 5)
				return Next();

			List<Card> fourOfAKind = Cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 4)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(4)
				.ToList();

			if (fourOfAKind.Count != 4)
				return Next();

			Card highCard = Cards.ToList()
				.FindAll(c => c.Value != fourOfAKind.First().Value)
				.OrderByDescending(c => c.Value)
				.First();

			List<Card> cards = new List<Card>(fourOfAKind);
			cards.Add(highCard);
			SetHandCards(cards);

			return true;
		}
	}
}
