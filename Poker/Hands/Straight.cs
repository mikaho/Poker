using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Straight : Hand
	{
		public Straight()
			: base(Constancts.HandRanks.Straight)
		{
		}


		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Maybe<Hand>.None;

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
				return Maybe<Hand>.None;

			return CreateCopy<Hand>(straight);
		}

		public override void SetHandName()
		{
			string cardName = HandNameHelper.HighCardName(CardsInTheHand.First());
			HandName = $"Suora - Korkea kortti {cardName}";
		}
	}
}
