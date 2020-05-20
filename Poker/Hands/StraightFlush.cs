using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class StraightFlush : Hand
	{
		public StraightFlush()
			: base(Constancts.HandRanks.StraightFlush)
		{
		}


		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return null;

			List<Card> cardsInSuit = HandHelper.GetSuitedCards(cards, 5, true);

			if (cardsInSuit.Count < 5)
				return null;

			List<Card> straightFlushCards = HandHelper.ResolveStraight(cardsInSuit);
			if (straightFlushCards.Count != 5)
				return null;

			return CreateCopy<StraightFlush>(straightFlushCards);
		}

		
	}
}
