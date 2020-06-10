using Poker.Common;
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

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() == 0)
				return Maybe<Hand>.None;

			List<Card> highCards = HandHelper.GetHighCards(cards);

			return CreateCopy<Hand>(highCards);
		}

		public override void SetHandName()
		{
			string cardName = CardsInTheHand.First().Value.ValueName();
			HandName = $"Hai - Korkea kortti {cardName}";
		}
	}
}
