using System;
using System.Collections.Generic;
using System.Text;

namespace Poker.Core
{
	public class Player
	{
		public Player(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
		}

		public Guid Id { get; }
		public string Name { get; }
	}
}
