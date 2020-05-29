using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Pair : Hand
	{
		public Pair()
			: base(Constancts.HandRanks.Pair)
		{
		}

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 2)
				return Maybe<Hand>.None;

			List<Card> pair = HandHelper.GetOfAKind(cards, 2);

			if (pair.Count != 2)
				return Maybe<Hand>.None;

			List<Card> highCards = HandHelper.GetHighCards(cards, pair);

			List<Card> finalCards = new List<Card>(pair);
			finalCards.AddRange(highCards);

			return CreateCopy<Hand>(finalCards);
		}
	}
}
