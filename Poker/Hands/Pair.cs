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

			if (cards.Count() < 2)
				return Next(cards);

			List<Card> pair = HandHelper.GetOfAKind(cards, 2);

			if (pair.Count != 2)
				return Next(cards);

			List<Card> highCards = HandHelper.GetHighCards(cards, pair);

			List<Card> finalCards = new List<Card>(pair);
			finalCards.AddRange(highCards);

			return CreateCopy<Pair>(finalCards);
		}
	}
}
