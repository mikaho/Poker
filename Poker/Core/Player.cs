using Poker.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Core
{
	public class Player : Entity
	{
		private List<Card> cards = new List<Card>();
		public Player(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public IReadOnlyList<Card> Cards => cards.ToList().AsReadOnly();

		public void AddCard(Card card)
		{
			cards.Add(card);
		}
	}
}
