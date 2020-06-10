using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core
{
	public static class CardValueExtensions
	{
		public static string ValueToString(this CardValue cardValue)
		{
			switch (cardValue.Value)
			{
				case 10:
					return "T";
				case 11:
					return "J";
				case 12:
					return "Q";
				case 13:
					return "K";
				case 14:
				case 1:
					return "A";
				default:
					return cardValue.Value.ToString();
			}
		}

		public static string ValueName(this CardValue cardValue)
		{
			switch (cardValue.Value)
			{
				case 2:
					return "Kakkoset";
				case 3:
					return "Kolmeset";
				case 4:
					return "Neloset";
				case 5:
					return "Vitoset";
				case 6:
					return "Kutoset";
				case 7:
					return "Seiskat";
				case 8:
					return "Kasit";
				case 9:
					return "Ysit";
				case 10:
					return "Kympit";
				case 11:
					return "Järkät";
				case 12:
					return "Akat";
				case 13:
					return "Kurkot";
				case 14:
					return "Ässät";
				default:
					throw new ArgumentOutOfRangeException($"Invalid value {cardValue.Value}");
			}
		}
	}
}
