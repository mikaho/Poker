using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class FullHouse : Hand
	{
		public FullHouse()
			: base(Constancts.HandRanks.FullHouse)
		{
		}

		public override Maybe<Hand> IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Maybe<Hand>.None;

			List<Card> treeOfAKind = HandHelper.GetOfAKind(cards, 3); ;

			if (treeOfAKind.Count != 3)
				return Maybe<Hand>.None;

			List<Card> remainingCard = cards.ToList()
				.FindAll(c => c.Value != treeOfAKind.First().Value);

			List<Card> pair = HandHelper.GetOfAKind(remainingCard, 2);

			if (pair.Count != 2)
				return Maybe<Hand>.None;

			List<Card> finalCards = new List<Card>(treeOfAKind);
			finalCards.AddRange(pair);

			return CreateCopy<Hand>(finalCards);
		}

		public override void SetHandName()
		{
			string threeOfAKind = CardsInTheHand.First().Value.ValueName();
			string pair = CardsInTheHand.Skip(3).First().Value.ValueName();
			HandName = $"Täysikäsi - {threeOfAKind} ja {pair}";
		}
	}
}
