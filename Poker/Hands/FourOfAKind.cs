using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FourOfAKind : Hand
	{
		public FourOfAKind()
			: base(Constancts.HandRanks.FourOfAKind)
		{
		}

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Maybe<Hand>.None;

			List<Card> fourOfAKind = HandHelper.GetOfAKind(cards, 4);

			if (fourOfAKind.Count != 4)
				return Maybe<Hand>.None;

			List<Card> highCards = HandHelper.GetHighCards(cards, fourOfAKind);

			List<Card> finalCards = new List<Card>(fourOfAKind);
			finalCards.Add(highCards.First());

			return CreateCopy<Hand>(finalCards);
		}

		public override void SetHandName()
		{
			string cardName = HandNameHelper.CardName(CardsInTheHand.First());
			HandName = $"Neljä samaa - {cardName}";
		}

	}
}
