namespace Poker.Core
{
	public class Suits : Enumeration
	{
		private Suits(int id, string name)
			: base(id, name)
		{
		}
		
		public static readonly Suits Hearts = new Suits(1, "Hearts");
		public static readonly Suits Dimensions = new Suits(2, "Dimensions");
		public static readonly Suits Spades = new Suits(3, "Spades");
		public static readonly Suits Clubes = new Suits(4, "Clubes");
	}
}
