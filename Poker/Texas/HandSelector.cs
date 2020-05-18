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
			TreeOfAKind treeOfAKind = new TreeOfAKind();
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
