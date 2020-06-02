using Poker.Common;
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

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Maybe<Hand>.None;

			List<Card> cardsInSuit = HandHelper.GetSuitedCards(cards);

			if (cardsInSuit.Count != 5)
				return Maybe<Hand>.None;

			return CreateCopy<Hand>(cardsInSuit);
		}

		public override void SetHandName()
		{
			string cardName = HandNameHelper.HighCardName(CardsInTheHand.First());
			HandName = $"Suora - Korkea kortti {cardName}";
		}
	}
}
