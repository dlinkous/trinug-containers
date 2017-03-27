using System;

namespace DomainEvents.Domain
{
	public class Level3 : ILevel3
	{
		private readonly ILevel4 level4;

		public Level3(ILevel4 level4)
		{
			this.level4 = level4;
		}

		public void Execute()
		{
			level4.Execute();
		}
	}
}
