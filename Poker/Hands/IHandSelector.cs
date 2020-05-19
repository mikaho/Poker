using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Hands
{
	public interface IHandSelector
	{
		Hand SelectBest(IEnumerable<Card> cards);
	}
}
