using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class Straight : Hand
	{
		public Straight(Hand next = null)
			: base(Constancts.HandRanks.Straight, next)
		{
		}


		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			ThrowIfDuplicate(cards);

			if (cards.Count() < 5)
				return Next(cards);

			List<Card> pairs = cards.GroupBy(s => s.Value)
				.Where(g => g.Count() == 2)
				.SelectMany(grp => grp)
				.OrderBy(c => c.Value)
				.ToList();

			List<Card> pairsRemoved = new List<Card>(cards);
			if (pairs.Count >= 2)
				pairsRemoved.Remove(pairs.Take(1).First());
			if (pairs.Count >= 4)
				pairsRemoved.Remove(pairs.Skip(2).Take(1).First());

			List<Card> cardsInStraight = pairsRemoved
				.OrderByDescending(c => c.Value)
				.ToList();

			List<Card> straight = ResolveStraight(cardsInStraight);
			if (straight.Count != 5)
				return Next(cards);

			SetHandCards(straight);

			return this;
		}

		private static List<Card> ResolveStraight(List<Card> cardsInSuit)
		{
			List<Card> straightCards = new List<Card>();
			Card ace = null;
			foreach (Card card in cardsInSuit)
			{
				if (!straightCards.Any())
				{
					if (card.Value == 14)
						ace = card;
					else
						straightCards.Add(card);
				}
				else
				{
					Card lastCard = straightCards.Last();
					if (lastCard.Value == card.Value + 1)
					{
						straightCards.Add(card);
					}
					else
					{
						if (straightCards.Count < 4)
						{
							straightCards.Clear();
							straightCards.Add(card);
						}
					}
				}
			}

			if (ace != null && straightCards.Count == 4)
			{
				Card firstCard = straightCards.First();
				if (firstCard.Value == 5)
					straightCards.Add(ace);
				else if (firstCard.Value == 13)
					straightCards.Insert(0, ace);
			}

			return straightCards.Take(5).ToList();
		}
	}
}
