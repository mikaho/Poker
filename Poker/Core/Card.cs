using Poker.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Poker.Core
{
	public class Card : ValueObject<Card>, ICloneable
	{
		public Card(Suits suit, int value)
		{
			Suit = suit;
			Value = value;
		}

		public Card(Suits suit, string value)
		{
			Suit = suit;
			Value = StringToValue(value);
		}

		private int StringToValue(string value)
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
					int.TryParse(value, out numericValue);
					break;
			}

			return numericValue;
		}

		public Suits Suit { get; }
		public int Value { get; }

		//public int CompareTo([NotNull] Card other)
		//{
		//	return other.Value.CompareTo(Value);
		//}

		//public override bool Equals(object obj)
		//{
		//	Card cardToCompare = obj as Card;
		//	if (cardToCompare == null)
		//		return false;

		//	return this.Value == cardToCompare.Value &&
		//		this.Suit == cardToCompare.Suit;
		//}

		//public override int GetHashCode()
		//{
		//	//TODO: Fix
		//	return base.GetHashCode();
		//}


		public override string ToString()
		{
			string valueInString = ValueToString();
			string suitInString = SuitToString();

			return $"{suitInString}{valueInString}";
		}

		private string SuitToString()
		{
			string suitInString = null;
			if (Suit == Suits.Hearts)
			{
				suitInString = "\u2764";
			}
			else if (Suit == Suits.Dimensions)
			{
				suitInString = "\u2666";
			}
			else if (Suit == Suits.Spades)
			{
				suitInString = "\u2660";
			}
			else if (Suit == Suits.Clubes)
			{
				suitInString = "\u2663";
			}

			return suitInString;
		}

		private string ValueToString()
		{
			string valueInString = null;
			switch (Value)
			{
				
				case 10:
					valueInString = "T";
					break;
				case 11:
					valueInString = "J";
					break;
				case 12:
					valueInString = "Q";
					break;
				case 13:
					valueInString = "K";
					break;
				case 14:
					valueInString = "A";
					break;
				default:
					valueInString = Value.ToString();
					break;
			}

			return valueInString;
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
	}
}
