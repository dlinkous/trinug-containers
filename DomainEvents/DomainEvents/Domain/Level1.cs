using System;

namespace DomainEvents.Domain
{
	public class Level1 : ILevel1
	{
		private readonly ILevel2 level2;

		public Level1(ILevel2 level2)
		{
			this.level2 = level2;
		}

		public void Execute()
		{
			level2.Execute();
		}
	}
}
