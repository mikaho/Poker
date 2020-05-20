using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class HighCard : Hand
	{
		public HighCard()
			: base(Constancts.HandRanks.HighCard)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() == 0)
				return null;

			List<Card> highCards = HandHelper.GetHighCards(cards);

			return CreateCopy<HighCard>(highCards);
		}
	}
}
