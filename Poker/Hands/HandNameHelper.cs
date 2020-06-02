using Poker.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Hands
{
	public static class HandNameHelper
	{
		public static string HighCardName(Card card)
		{
			switch (card.Value)
			{
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					return card.Value.ToString();
				case 10:
					return "Kymppi";
				case 11:
					return "Jätkä";
				case 12:
					return "Akka";
				case 13:
					return "Kurko";
				case 14:
					return "Ässä";
				default:
					throw new ArgumentOutOfRangeException($"Invalid value {card.Value}");

			}
		}

		public static string CardName(Card card)
		{
			switch (card.Value)
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
					throw new ArgumentOutOfRangeException($"Invalid value {card.Value}");
			}
		}
	}
}
