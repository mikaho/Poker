using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Ranks
{
	public class HandRank
	{
		public int Position { get; }
		private List<Player> players = new List<Player>();
		public Hand Hand { get; }

		public IReadOnlyList<Player> Players => players.ToList().AsReadOnly();
		public HandRank(int position, Hand hand)
		{
			Position = position;
			this.Hand = hand;
		}

		public void AddPlayer(Player player)
		{
			if (!players.Contains(player))
				players.Add(player);
		}

		internal bool IsSame(Hand hand)
		{
			if (!players.Any())
				return false;

			return Hand.CompareTo(hand) == 0;
		}
	}
}
