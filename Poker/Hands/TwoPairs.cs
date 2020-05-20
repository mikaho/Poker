using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class TwoPairs : Hand
	{
		public TwoPairs()
			: base(Constancts.HandRanks.TwoPairs)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return null;

			List<Card> highPair = HandHelper.GetOfAKind(cards, 2);
			List<Card> remaining = HandHelper.GetRemainingCards(cards, highPair);
			List<Card> lowPair = HandHelper.GetOfAKind(remaining, 2);
			List<Card> twoPairs = highPair.Concat(lowPair).ToList();

			if (twoPairs.Count != 4)
				return null;

			List<Card> highCards = HandHelper.GetRemainingCards(cards, twoPairs);
			Card highCard = highCards.OrderByDescending(c => c.Value).First();
			List<Card> finalCards = new List<Card>(twoPairs);
			finalCards.Add(highCard);

			return CreateCopy<TwoPairs>(finalCards);
		}
	}
}
