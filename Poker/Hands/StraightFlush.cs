using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class StraightFlush : Hand
	{
		public StraightFlush(Hand next = null)
			: base(Constancts.HandRanks.StraightFlush, next)
		{
		}


		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> cardsInSuit = HandHelper.GetSuitedCards(cards, 5, true);

			if (cardsInSuit.Count < 5)
				return Next(cards);

			List<Card> straightFlushCards = HandHelper.ResolveStraight(cardsInSuit);
			if (straightFlushCards.Count != 5)
				return Next(cards);

			return CreateCopy<StraightFlush>(straightFlushCards);
		}

		
	}
}
