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
		public Card(Suits suit, CardValue value)
		{
			ThrowIfValueOutOfRange(value);

			Suit = suit;
			Value = value;
		}

		private static void ThrowIfValueOutOfRange(CardValue value)
		{
			if (!(value >= 1 && value <= 14))
				throw new ArgumentOutOfRangeException("Card value");
		}

		public Card(Suits suit, string value)
		{
			Suit = suit;
			Value = value;
		}

		public Suits Suit { get; }
		public CardValue Value { get; }

		public override string ToString()
		{
			return $"{Suit.Symbol}{Value}";
		}

		public static implicit operator string(Card c) => c.ToString();

		public static implicit operator Card(string suitAndValue)
		{
			return FromSuitAndValue(suitAndValue);
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

		public static Card FromSuitAndValue(string suitAndValue)
		{
			if (string.IsNullOrEmpty(suitAndValue))
				throw new ArgumentNullException("suitAndValue");

			if (suitAndValue.Length != 2)
				throw new ArgumentNullException("suitAndValue");

			string suitsInString = suitAndValue.Substring(0, 1);
			string valueInString = suitAndValue.Substring(1, 1);

			Suits suit = Suits.GetAll<Suits>().FirstOrDefault(s => s.Symbol == suitsInString);
			if (suit == null)
				throw new ArgumentOutOfRangeException("suit");
			CardValue value = valueInString;
			
			return new Card(suit, value);
		}
	}
}
