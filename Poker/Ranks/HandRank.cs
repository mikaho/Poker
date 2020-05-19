using Poker.Core;
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
		public IReadOnlyList<Player> Players => players.ToList().AsReadOnly();
		public HandRank(int position)
		{
			Position = position;
		}

		public void AddPlayer(Player player)
		{
			if (!players.Contains(player))
				players.Add(player);
		}
	}
}
