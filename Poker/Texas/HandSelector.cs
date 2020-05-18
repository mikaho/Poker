using Poker.Core;
using Poker.Hands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Texas
{
	public class TexasHandSelector
	{
		private readonly Hand root;
		public TexasHandSelector()
		{
			Pair pair = new Pair();
			TwoPairs twoPairs = new TwoPairs(pair);
			TreeOfAKind treeOfAKind = new TreeOfAKind(twoPairs);
			Straight straight = new Straight(treeOfAKind);
			Flush flush = new Flush(straight);
			FullHouse fullHouse = new FullHouse(flush);
			FourOfAKind fourOfAKind = new FourOfAKind(fullHouse);
			StraightFlush straightFlush = new StraightFlush(fourOfAKind);
			root = straightFlush;
		}

		public Hand SelectBest(IEnumerable<Card> cards)
		{
			return root.IsMatch(cards);
		}
	}
}
