using Poker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core
{
	public abstract class Game : AggregateRoot
	{
		protected int NumberOfDealsDone;
		protected Deck deck;

		public Game(Deck deck)
		{
			this.deck = deck;
			this.deck.Suffle();
		}

		List<Player> players = new List<Player>();
		public IReadOnlyList<Player> Players => players.ToList().AsReadOnly();

		public Deck Deck => deck;

		public void AddPlayer(Player player)
		{
			if (!players.Exists(p => p.Id == player.Id))
			{
				players.Add(player);
			}
		}

		public abstract void Deal();
		public abstract int DealsLeft { get; }

		public void IncrementNumberOfDeals()
		{
			if (DealsLeft > 0)
				NumberOfDealsDone++;
		}
	}
}
