using System;

namespace DomainEvents.Domain
{
	public class Level2 : ILevel2
	{
		private readonly ILevel3 level3;

		public Level2(ILevel3 level3)
		{
			this.level3 = level3;
		}

		public void Execute()
		{
			level3.Execute();
		}
	}
}
