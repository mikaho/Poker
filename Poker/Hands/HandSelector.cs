using Poker.Common;
using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Poker.Hands
{
	public abstract class HandSelector 
	{
		protected readonly List<Hand> hands = new List<Hand>();

		public Maybe<Hand> SelectBest(IEnumerable<Card> cards)
		{
			foreach (var hand in hands)
			{
				Maybe<Hand> found = hand.IsMatch(cards);
				if (found.HasValue)
					return found;
			}

			return Maybe<Hand>.None;
		}
	}
}
