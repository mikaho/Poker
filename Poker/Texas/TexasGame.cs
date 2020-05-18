using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Texas
{
	public class TexasGame : Game
	{
		List<Card> doardCards = new List<Card>();
		public IReadOnlyList<Card> DoardCards => doardCards.ToList().AsReadOnly();
		const int DelasInTexas = 4;

		public override int DealsLeft
		{
			get
			{
				return DelasInTexas - NumberOfDeals;
			}
		}

		public TexasGame(Deck deck)
			: base(deck)
		{

		}

		public override void Deal()
		{
			if (NumberOfDeals == 0)
			{
				DealPlayerCards();
			}
			else if (NumberOfDeals == 1)
			{
				DealFlop();
			}
			else if (NumberOfDeals == 2)
			{
				DealTurn();
			}
			else if (NumberOfDeals == 3)
			{
				DealRiver();
			}

			IncrementNumberOfDeals();
		}

		private void DealPlayerCards()
		{
			int expected = PlayerCards.Count * 2;
			while (PlayerCards.Sum(p => p.Cards.Count) != expected)
			{
				foreach (PlayerCards playerCards in PlayerCards)
				{
					if (playerCards.Cards.Count < 2)
					{
						Card card = deck.TakeTopMostCard();
						playerCards.AddCard(card);
					}
				}
			}
		}

		private void DealFlop()
		{
			BurnACard();

			while (doardCards.Count < 3)
			{
				Card card = deck.TakeTopMostCard();
				doardCards.Add(card);
			}
		}

		private void DealTurn()
		{
			BurnACard();

			Card card = deck.TakeTopMostCard();
			doardCards.Add(card);
		}

		private void DealRiver()
		{
			BurnACard();

			Card card = deck.TakeTopMostCard();
			doardCards.Add(card);
		}

		private void BurnACard()
		{
			deck.TakeTopMostCard();
		}

		public bool HasDealLeft()
		{
			return DealsLeft > 0;
		}
	}
}
