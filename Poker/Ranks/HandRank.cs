using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Ranks
{
	public class HandRank
	{
		private List<PlayerCards> playerCards = new List<PlayerCards>();
		public IReadOnlyList<PlayerCards> PlayerCards => playerCards.ToList().AsReadOnly();

		public void AddPlayerCards(IEnumerable<PlayerCards> playerCards)
		{
			this.playerCards.Clear();
			this.playerCards.AddRange(playerCards);
		}
	}
}
