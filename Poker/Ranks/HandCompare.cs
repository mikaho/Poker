﻿using Poker.Common;
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
		private readonly HandSelector handSelector;

		public HandCompare(HandSelector handSelector)
		{
			this.handSelector = handSelector;
		}

		public IReadOnlyList<HandRank> RankPlayerHands(IEnumerable<Player> players, IEnumerable<Card> doardCards)
		{
			ThrowIfDuplicate(players, doardCards);

			Dictionary<Player, Hand> hands = new Dictionary<Player, Hand>();
			foreach (Player player in players)
			{
				List<Card> cards = new List<Card>(player.Cards);
				cards.AddRange(doardCards);

				Maybe<Hand> hand = handSelector.SelectBest(cards);
				if (!hand.HasValue)
					throw new InvalidOperationException("Hand not ranked.");

				hands.Add(player, hand.Value);
			}

			List<HandRank> handRanks = new List<HandRank>();
			var hardsInOrder = hands.ToList().OrderByDescending(h => h.Value);
			HandRank handRank = null;
			foreach (var current in hardsInOrder)
			{
				if (!handRanks.Any())
				{
					handRank = AddNew(handRanks, current);
				}
				else
				{
					if (handRank.IsSame(current.Value))
					{
						handRank.AddPlayer(current.Key);
					}
					else
					{
						handRank = AddNew(handRanks, current);
					}
				}
			}

			return handRanks;
		}

		private void ThrowIfDuplicate(IEnumerable<Player> players, IEnumerable<Card> doardCards)
		{
			List<Card> cards = new List<Card>(doardCards);
			players.ToList().ForEach(p => cards.AddRange(p.Cards));

			HandHelper.ThrowIfDuplicate(cards);
		}

		private static HandRank AddNew(List<HandRank> handRanks, KeyValuePair<Player, Hand> current)
		{
			HandRank handRank = new HandRank(handRanks.Count + 1, current.Value);
			handRank.AddPlayer(current.Key);
			handRanks.Add(handRank);
			return handRank;
		}
	}
}
