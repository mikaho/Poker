using Poker.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Poker.Core
{
	public class Card : ValueObject<Card>, ICloneable
	{
		public Card(Suits suit, int value)
		{
			ThrowIfValueOutOfRange(value);

			Suit = suit;
			Value = value;
		}

		private static void ThrowIfValueOutOfRange(int value)
		{
			if (!(value >= 1 && value <= 14))
				throw new ArgumentOutOfRangeException("Card value");
		}

		public Card(Suits suit, string value)
		{
			Suit = suit;
			Value = StringToValue(value);
		}

		private static int StringToValue(string value)
		{
			int numericValue = 0;
			if (value.Length != 1)
				return numericValue;

			switch (value)
			{
				case "T":
					numericValue = 10; 
					break;
				case "J":
					numericValue = 11;
					break;
				case "Q":
					numericValue = 12;
					break;
				case "K":
					numericValue = 13;
					break;
				case "A":
					numericValue = 14;
					break;
				default:
					if (!int.TryParse(value, out numericValue))
						throw new ArgumentOutOfRangeException("Card value");
					break;
			}

			return numericValue;
		}

		public Suits Suit { get; }
		public int Value { get; }

		public override string ToString()
		{
			string valueInString = ValueToString();
			return $"{Suit.Symbol}{valueInString}";
		}

		private string ValueToString()
		{
			switch (Value)
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
					return Value.ToString();
			}
		}

		protected override bool EqualsCore(Card other)
		{
			return Value == other.Value && Suit == other.Suit;
		}

		protected override int GetHashCodeCore()
		{
			return $"{Suit}{Value}".GetHashCode();
		}

		public object Clone()
		{
			return new Card(Suit, Value); 
		}

		public static Card FromSymbol(string symbol)
		{
			if (string.IsNullOrEmpty(symbol))
				throw new ArgumentNullException("Symbol");

			if (symbol.Length != 2)
				throw new ArgumentNullException("Symbol");

			string suitsInString = symbol.Substring(0, 1);
			string valueInString = symbol.Substring(1, 1);

			Suits suit = Suits.GetAll<Suits>().First(s => s.Symbol == suitsInString);
			int value = StringToValue(valueInString);

			return new Card(suit, value);
		}
	}
}
