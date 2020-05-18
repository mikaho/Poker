﻿using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class TwoPairs : Hand
	{
		public TwoPairs(Hand next = null)
			: base(Constancts.HandRanks.TwoPairs, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> twoPairs = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() >= 2)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.Take(4)
				.ToList();

			if (twoPairs.Count != 4)
				return Next(cards);

			Card highCard = cards.ToList()
				.FindAll(c => !twoPairs.Contains(c))
				.OrderByDescending(c => c.Value)
				.First();

			List<Card> finalCards = new List<Card>(twoPairs);
			finalCards.Add(highCard);
			SetHandCards(finalCards);

			return this;
		}
	}
}