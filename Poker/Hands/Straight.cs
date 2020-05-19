﻿using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Straight : Hand
	{
		public Straight(Hand next = null)
			: base(Constancts.HandRanks.Straight, next)
		{
		}


		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> pairs = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() == 2)
				.SelectMany(grp => grp)
				.OrderBy(c => c.Value)
				.ToList();

			List<Card> pairsRemoved = new List<Card>(cards);
			//TODO: Improve
			if (pairs.Count >= 2)
				pairsRemoved.Remove(pairs.Take(1).First());
			if (pairs.Count >= 4)
				pairsRemoved.Remove(pairs.Skip(2).Take(1).First());

			List<Card> cardsInStraight = pairsRemoved
				.OrderByDescending(c => c.Value)
				.ToList();

			List<Card> straight = HandHelper.ResolveStraight(cardsInStraight);
			if (straight.Count != 5)
				return Next(cards);

			SetHandCards(straight);

			return this;
		}
	}
}
