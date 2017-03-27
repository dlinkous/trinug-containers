using System;
using DomainEvents.Events;

namespace DomainEvents.Domain
{
	public class Level5 : ILevel5
	{
		private readonly IPublisher publisher;

		public Level5(IPublisher publisher)
		{
			this.publisher = publisher;
		}

		public void Execute()
		{
			publisher.Publish(new FileSavedEvent("TestFileName"));
		}
	}
}
