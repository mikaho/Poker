using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FourOfAKind : Hand
	{
		public FourOfAKind(Hand next = null)
			: base(Constancts.HandRanks.FourOfAKind, next)
		{
		}

		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> fourOfAKind = HandHelper.GetOfAKind(cards, 4);

			if (fourOfAKind.Count != 4)
				return Next(cards);

			List<Card> highCards = HandHelper.GetHighCards(cards, fourOfAKind);

			List<Card> finalCards = new List<Card>(fourOfAKind);
			finalCards.Add(highCards.First());

			return CreateCopy<FourOfAKind>(finalCards);
		}

		
	}
}
