using Poker.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Poker.Core
{
	public class CardValue : ValueObject<CardValue>, ICloneable, IComparable<CardValue>
	{
		private readonly int value;
		private CardValue(int value)
		{
			this.value = value;
		}

		private static string ValueToString(int value)
		{
			switch (value)
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
					return value.ToString();
			}
		}

		private static int StringToValue(string stringValue)
		{
			int numericValue = 0;
			if (stringValue.Length != 1)
				return numericValue;

			switch (stringValue)
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
					if (!int.TryParse(stringValue, out numericValue))
						throw new ArgumentOutOfRangeException("Card value");
					break;
			}

			return numericValue;
		}

		public string ValueName()
		{
			switch (value)
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
					throw new ArgumentOutOfRangeException($"Invalid value {value}");
			}
		}

		public object Clone()
		{
			return new CardValue(value);
		}

		protected override bool EqualsCore(CardValue other)
		{
			return value == other.value;
		}

		protected override int GetHashCodeCore()
		{
			return value.GetHashCode();
		}

		public static implicit operator CardValue(int value)
		{
			return new CardValue(value);
		}

		public int CompareTo([NotNull]CardValue otherCard)
		{
			return value.CompareTo(otherCard.value);
		}

		public static implicit operator CardValue(string value)
		{
			return new CardValue(StringToValue(value));
		}

		public static bool operator == (CardValue a, CardValue b)
			=> a.value == b.value;

		public static bool operator !=(CardValue a, CardValue b)
			=> a.value != b.value;

		public static bool operator >=(CardValue a, CardValue b)
			=> a.value >= b.value;

		public static bool operator <=(CardValue a, CardValue b)
			=> a.value <= b.value;

		public static int operator +(CardValue a, int toAdd)
			=> a.value + toAdd;

		public static implicit operator int(CardValue c) => c.value;
		
		public override string ToString()
		{
			return ValueToString(value);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return GetHashCodeCore();
		}

		public int CompareTo(object other)
		{
			CardValue cardValue = other as CardValue;
			return CompareTo(cardValue);
		}
	}
}
