using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class StraightFlush : Hand
	{
		public StraightFlush(Hand next = null)
			: base(Constancts.HandRanks.StraightFlush, next)
		{
		}


		public override Hand IsMatch(IEnumerable<Card> cards)
		{
			if (cards.Count() < 5)
				return Next(cards);

			List<Card> cardsInSuit = cards.GroupBy(s => s.Suit)
				.Where(g => g.Count() >= 5)
				.SelectMany(grp => grp)
				.OrderByDescending(c => c.Value)
				.ToList();

			if (cardsInSuit.Count < 5)
				return Next(cards);

			List<Card> straightFlushCards = ResolveStraight(cardsInSuit);
			if (straightFlushCards.Count != 5)
				return Next(cards);

			SetHandCards(straightFlushCards);

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
