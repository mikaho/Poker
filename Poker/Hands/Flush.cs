using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Flush : Hand
	{
		public Flush()
			: base(Constancts.HandRanks.Flush)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return null;

			List <Card> cardsInSuit = HandHelper.GetSuitedCards(cards);

			if (cardsInSuit.Count != 5)
				return null;

			return CreateCopy<Flush>(cardsInSuit);
		}
	}
}
