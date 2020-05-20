using Poker.Core;
using Poker.Hands;
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
				return DelasInTexas - NumberOfDealsDone;
			}
		}

		public TexasGame(Deck deck)
			: base(deck)
		{

		}

		public override void Deal()
		{
			if (NumberOfDealsDone == 0)
			{
				DealPlayerCards();
			}
			else if (NumberOfDealsDone == 1)
			{
				DealFlop();
			}
			else if (NumberOfDealsDone == 2)
			{
				DealTurn();
			}
			else if (NumberOfDealsDone == 3)
			{
				DealRiver();
			}

			IncrementNumberOfDeals();
		}

		private void DealPlayerCards()
		{
			int expected = Players.Count * 2;
			while (Players.Sum(p => p.Cards.Count) != expected)
			{
				foreach (Player player in Players)
				{
					if (player.Cards.Count < 2)
					{
						Card card = deck.TakeTopMostCard();
						player.AddCard(card);
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

		private readonly TexasHandSelector handSelector = new TexasHandSelector();
		public HandSelector HandSelector => handSelector;


	}
}
