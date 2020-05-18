using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core
{
	public static class Constancts
	{
		public static class CardValues
		{
			public static readonly int Ten = 10;
			public static readonly int Jack = 11;
			public static readonly int Queen = 12;
			public static readonly int King = 13;
			public static readonly int Ace = 14;
		}

		public static class HandRanks
		{
			public static readonly int StraightFlush = 1000;
			public static readonly int FourOfAKind = 900;
			public static readonly int FullHouse = 800;
			public static readonly int Flush = 700;
			public static readonly int Straight = 600;
			public static readonly int ThreeOfAKind = 500;
			public static readonly int TwoPairs = 400;
			public static readonly int Pair = 300;
			public static readonly int HighCard = 200;
		}
	}
}
