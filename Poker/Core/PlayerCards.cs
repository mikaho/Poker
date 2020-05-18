using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Poker.Core
{
	public class PlayerCards
	{
		private List<Card> cards = new List<Card>();
		public PlayerCards(Player player)
		{
			Player = player;
		}

		public Player Player { get; }
		public IReadOnlyList<Card> Cards => cards.ToList().AsReadOnly();

		public void AddCard(Card card)
		{
			cards.Add(card);
		}
	}
}
