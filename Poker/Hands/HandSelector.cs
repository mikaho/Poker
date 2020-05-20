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

		public Hand SelectBest(IEnumerable<Card> cards)
		{
			Hand found = null;
			foreach (var hand in hands)
			{
				found = hand.IsMatch(cards);
				if (found != null)
					return found;
			}

			return found;
		}
	}
}
