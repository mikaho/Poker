using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class TreeOfAKind : Hand
	{
		public TreeOfAKind()
			: base(Constancts.HandRanks.ThreeOfAKind)
		{
		}

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Maybe<Hand>.None;

			List<Card> threeOfAKind = HandHelper.GetOfAKind(cards, 3);

			if (threeOfAKind.Count != 3)
				return Maybe<Hand>.None;

			List<Card> highCards = HandHelper.GetHighCards(cards, threeOfAKind);

			List<Card> finalCards = new List<Card>(threeOfAKind);
			finalCards.AddRange(highCards);

			return CreateCopy<Hand>(finalCards);
		}

		public override void SetHandName()
		{
			string cardName = HandNameHelper.CardName(CardsInTheHand.First());
			HandName = $"Kolme samaa - {cardName}";
		}
	}
}
