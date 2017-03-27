using System;

namespace DomainEvents.Domain
{
	public class Level4 : ILevel4
	{
		private readonly ILevel5 level5;

		public Level4(ILevel5 level5)
		{
			this.level5 = level5;
		}

		public void Execute()
		{
			level5.Execute();
		}
	}
}
