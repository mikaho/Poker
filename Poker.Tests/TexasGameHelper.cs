using Poker.Core;
using Poker.Texas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Tests
{
	public class TexasGameHelper
	{
		public static TexasGame Create()
		{
			Deck deck = new Deck();
			TexasGame texasGame = new TexasGame(deck);
			texasGame.AddPlayer(new Player("Mika"));
			texasGame.AddPlayer(new Player("Masa"));
			return texasGame;
		}
	}
}
