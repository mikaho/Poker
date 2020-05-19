using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Hands
{
	public class HandHelper
	{
		public static List<Card> ResolveStraight(List<Card> cardsInSuit)
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

			if (ace != null)
			{
				Card firstCard = straightCards.First();
				if (firstCard.Value == 5)
				{
					straightCards.Add(ace);
				}
				else if (firstCard.Value == 13)
				{
					straightCards.Insert(0, ace);
				}
			}

			return straightCards.Take(5).ToList();
		}

		public static List<Card> GetOfAKind(IEnumerable<Card> cards, int kindCount)
		{
			return cards.GroupBy(s => s.Value)
							.Where(g => g.Count() >= kindCount)
							.SelectMany(grp => grp)
							.OrderByDescending(c => c.Value)
							.Take(kindCount)
							.ToList();
		}


		public static List<Card> GetHighCards(IEnumerable<Card> cards, List<Card> cardsToRemove)
		{
			List<Card> remaining = cards.ToList()
				.FindAll(c => c.Value != cardsToRemove.First().Value);
			return GetHighCards(remaining)
				.Take(5 - cardsToRemove.Count)
				.ToList();
		}

		public static List<Card> GetRemainingCards(IEnumerable<Card> cards, List<Card> cardsToRemove)
		{
			List<Card> remaining = cards.ToList()
					.FindAll(c => !cardsToRemove.Contains(c));
			return remaining;
		}

		public static List<Card> GetHighCards(IEnumerable<Card> cards)
		{
			return cards.ToList()
							.OrderByDescending(c => c.Value)
							.Take(5)
							.ToList();
		}

		public static List<Card> GetSuitedCards(IEnumerable<Card> cards, int suitCount = 5, bool takeAll = false)
		{
			int take = takeAll ? cards.Count() : suitCount;
			return cards.GroupBy(s => s.Suit)
							.Where(g => g.Count() >= suitCount)
							.SelectMany(grp => grp)
							.OrderByDescending(c => c.Value)
							.Take(take)
							.ToList();
		}

		public static void ThrowIfDuplicate(IEnumerable<Card> cards)
		{
			var duplicates = cards.GroupBy(s => new { s.Suit, s.Value })
				.SelectMany(grp => grp.Skip(1));

			if (duplicates.Any())
				throw new InvalidOperationException();
		}
	}
}
