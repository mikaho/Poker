using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker.Texas
{
	public class TexasHandSelector : HandSelector
	{
		public TexasHandSelector()
		{
			hands.AddRange(new List<Hand> {
				new StraightFlush(),
				new FourOfAKind(),
				new FullHouse(),
				new Flush(),
				new Straight(),
				new TreeOfAKind(),
				new TwoPairs(),
				new Pair(),
				new HighCard()
			});
		}
	}
}
