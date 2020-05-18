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
			: base(Constancts.HandRanks.HighCard, null)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() == 0)
				return Next(cards);


			List<Card> highCards = HandHelper.GetHighCards(cards);
			SetHandCards(highCards);

			return this;
		}
	}
}
