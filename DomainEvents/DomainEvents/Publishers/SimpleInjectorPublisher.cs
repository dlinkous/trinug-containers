using System;
using SimpleInjector;

namespace DomainEvents.Publishers
{
	public class SimpleInjectorPublisher : IPublisher
	{
		private readonly Container container;

		public SimpleInjectorPublisher(Container container)
		{
			this.container = container;
		}

		public void Publish<T>(T e) where T : IEvent
		{
			var handlers = container.GetAllInstances<IHandler<T>>();
			foreach (var handler in handlers)
			{
				handler.Handle(e);
			}
		}
	}
}
