using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class TreeOfAKind : Hand
	{
		public TreeOfAKind(Hand next = null)
			: base(Constancts.HandRanks.ThreeOfAKind, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> threeOfAKind = HandHelper.GetOfAKind(cards, 3);

			if (threeOfAKind.Count != 3)
				return Next(cards);

			List<Card> highCards = HandHelper.GetHighCards(cards, threeOfAKind);

			List<Card> finalCards = new List<Card>(threeOfAKind);
			finalCards.AddRange(highCards);
			SetHandCards(finalCards);

			return this;
		}

		
	}
}
