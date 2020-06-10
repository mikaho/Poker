using Poker.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Poker.Core
{
	public class CardValue : ValueObject<CardValue>, ICloneable, IComparable<CardValue>
	{
		public readonly int Value;
		private CardValue(int value)
		{
			Value = value;
		}

		public object Clone()
		{
			return new CardValue(Value);
		}

		protected override bool EqualsCore(CardValue other)
		{
			return Value == other.Value;
		}

		protected override int GetHashCodeCore()
		{
			return Value.GetHashCode();
		}

		public static implicit operator CardValue(int value)
		{
			return new CardValue(value);
		}

		public int CompareTo([NotNull]CardValue otherCard)
		{
			return Value.CompareTo(otherCard.Value);
		}

		public static implicit operator CardValue(string value)
		{
			return new CardValue(StringToValue(value));
		}

		private static int StringToValue(string stringValue)
		{
			int numericValue = 0;
			if (stringValue.Length != 1)
				throw new ArgumentOutOfRangeException(nameof(stringValue));

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
						throw new ArgumentOutOfRangeException(nameof(stringValue));
					break;
			}

			return numericValue;
		}

		public static bool operator == (CardValue a, CardValue b)
			=> a.Value == b.Value;

		public static bool operator !=(CardValue a, CardValue b)
			=> a.Value != b.Value;

		public static bool operator >=(CardValue a, CardValue b)
			=> a.Value >= b.Value;

		public static bool operator <=(CardValue a, CardValue b)
			=> a.Value <= b.Value;

		public static int operator +(CardValue a, int toAdd)
			=> a.Value + toAdd;

		public static implicit operator int(CardValue c) => c.Value;
		
		public override string ToString()
		{
			return this.ValueToString();
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
