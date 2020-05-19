using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Ranks
{
	public class HandCompare
	{
		private readonly IHandSelector handSelector;

		public HandCompare(IHandSelector handSelector)
		{
			this.handSelector = handSelector;
		}

		public IReadOnlyList<HandRank> RankPlayerHands(IEnumerable<PlayerCards> playerCards, IEnumerable<Card> doardCards)
		{
			Dictionary<Player, Hand> hands = new Dictionary<Player, Hand>();
			foreach (PlayerCards player in playerCards)
			{
				List<Card> cards = new List<Card>(player.Cards);
				cards.AddRange(doardCards);

				Hand hand = handSelector.SelectBest(cards);
				hands.Add(player.Player, hand);
			}

			//hands.Values.OrderByDescending(h => h.Rank)

			return null;
		}
	}
}
