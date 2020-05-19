using Poker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Tests
{
	public class TestHelper
	{
		public static List<Player> CreatePlayers(int count = 2)
		{
			List<Player> players = new List<Player>
			{
				new Player("Mika"),
				new Player("Masa"),
				new Player("Pirkko"),
				new Player("Pate"),
				new Player("Ile"),
				new Player("Lara"),
				new Player("Hulda"),
				new Player("Tinka")
			};

			return players.Take(count).ToList();
		}

		public static void AddCardsToPlayer(List<Player> players, string name, params Card[] cards)
		{
			Player p = players.Find(p => p.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
			foreach (Card c in cards)
			{
				p.AddCard(c);
			}
		}
	}
}
