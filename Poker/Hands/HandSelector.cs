using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Hands
{
	public class HandSelector : IHandSelector
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
